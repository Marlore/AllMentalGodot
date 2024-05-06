using Engine.PlayerEngine;
using Entity.People;
using Godot;
using System;
using System.Collections.Generic;

public partial class ProfileShort : HBoxContainer
{
    VBoxContainer PeopleContainer;
    VBoxContainer PeopleShortPanel;
    VBoxContainer PeopleFullProfile;
    List<Button> PeopleInfoButtons = new List<Button>();
    PackedScene Preset;
    public override void _Ready()
    {
        PeopleShortPanel = (VBoxContainer)this.GetNode("PersonShort");
        PeopleFullProfile = (VBoxContainer)this.GetNode("PersonFull");
        PeopleContainer = (VBoxContainer)this.GetNode("PersonShort/ScrollContainer/PeopleContainer");
        Preset = (PackedScene)ResourceLoader.Load("res://obj/Presets/Person.tscn");
        foreach (var person in PlayerInfo.CurrentCity.Population)
        {
            CreateButton(person);
        }
    }
    public void CreateButton(KeyValuePair<Guid, Person> person)
    {
        Button but = (Button)Preset.Instantiate();
        PeopleInfoButtons.Add(but);
        PeopleContainer.AddChild(but);
        but.Text = person.Value.FirstName + " " + person.Value.SecondName;
        but.Call("UpdateId", person.Key.ToString());
        
    }
    public void OnSearching(string str)
    {
        var NotEnableList = PeopleInfoButtons.FindAll(x => !(x.Text.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0));
        var EnableList = PeopleInfoButtons.FindAll(x => x.Text.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0);
        foreach (var button in NotEnableList)
        {
            button.Visible = false;
        }
        foreach (var button in EnableList)
        {
            button.Visible = true;
        }
    }
}
