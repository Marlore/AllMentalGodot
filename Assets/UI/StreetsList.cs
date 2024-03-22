using Godot;
using System;
using Engine.PlayerEngine;
using Entity.People;
using System.Collections.Generic;
using Data.StreetData;

public partial class StreetsList : VBoxContainer
{
    VBoxContainer StreetContainer;
    List<Button> StreetInfoButtons = new List<Button>();
    PackedScene Preset;
    public override void _Ready()
	{
        Preset = (PackedScene)ResourceLoader.Load("res://obj/Presets/Streets.tscn"); 
        foreach (var street in PlayerInfo.CurrentCity.CityStreets)
        {
            CreateButton(street);
        }
    }
    public void CreateButton(Streets street)
    {
        Button but = (Button)Preset.Instantiate();
        StreetInfoButtons.Add(but);
        this.AddChild(but);
        but.Text = street.Adress;
        but.Call("UpdateId", street.Id.ToString());
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
