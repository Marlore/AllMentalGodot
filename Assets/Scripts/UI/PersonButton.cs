using Engine.PlayerEngine;
using Entity.MurderEntity;
using Godot;
using System;

public partial class PersonButton : Button
{
    VBoxContainer PeopleShortPanel;
    VBoxContainer FullProfiler;
    public string PersonId;
	public void UpdateId(string id)=> PersonId = id;
    public override void _Ready()
    {
        base._Ready();
        PeopleShortPanel = (VBoxContainer)this.GetTree().Root.GetNode("MainDesk/CanvasLayer/Panel/Interface/HBoxContainer/SecondTree/PersonList/PersonShort");
        FullProfiler = (VBoxContainer)this.GetTree().Root.GetNode("MainDesk/CanvasLayer/Panel/Interface/HBoxContainer/SecondTree/PersonList/PersonFull");
        FullProfiler.Scale = Vector2.Zero;
    }
    private void _on_pressed()
	{
        FullProfiler.SizeFlagsStretchRatio = 1;
        FullProfiler.Call("Open", PersonId);
        foreach(var murder in PlayerInfo.CurrentCity.CityMurders)
        {
            if (murder.HuntTarget != null)
                GD.Print(murder.HuntTarget.FirstName + " " + murder.HuntTarget.SecondName+ " "+ murder.Weapon.Name);
        }
	}
}



