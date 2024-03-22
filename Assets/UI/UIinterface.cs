using Godot;
using System;

public partial class UIinterface : BoxContainer
{
	VBoxContainer PersonLibrary;
	VBoxContainer StreetLibrary;
	public override void _Ready()
	{
		PersonLibrary = (VBoxContainer)this.GetNode("HBoxContainer/BoxContainer/PersonList");
        StreetLibrary = (VBoxContainer)this.GetNode("HBoxContainer/BoxContainer/StreetsList");
        PersonLibrary.Visible = false;
        StreetLibrary.Visible = false;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void PersonLibraryOpen()
	{
        PersonLibrary.Visible = true;
		StreetLibrary.Visible = false;
    }
	public void StreetsLibraryOpen()
	{
        PersonLibrary.Visible = false;
        StreetLibrary.Visible = true;
    }
}
