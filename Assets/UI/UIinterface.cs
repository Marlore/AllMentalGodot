using Godot;
using System;

public partial class UIinterface : BoxContainer
{
    HBoxContainer PersonLibrary;
	VBoxContainer StreetLibrary;

    public override void _Ready()
	{
		PersonLibrary = (HBoxContainer)this.GetNode("HBoxContainer/SecondTree/PersonList");
        StreetLibrary = (VBoxContainer)this.GetNode("HBoxContainer/SecondTree/StreetsList");
        PersonLibrary.Visible = false;
        StreetLibrary.Visible = false;
        
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void PersonLibraryOpen()
	{
        if (PersonLibrary.Visible != true) 
        { 
            PersonLibrary.Visible = true;
	        StreetLibrary.Visible = false;
        }
    }
	public void StreetsLibraryOpen()
	{
        if (StreetLibrary.Visible != true)
        {
            PersonLibrary.Visible = false;
            StreetLibrary.Visible = true;
        }
    }
}
