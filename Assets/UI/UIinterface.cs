using Godot;
using System;

public partial class UIinterface : BoxContainer
{
    HBoxContainer PersonLibrary;
	VBoxContainer StreetLibrary;
    Tween tween;

    public override void _Ready()
	{
		PersonLibrary = (HBoxContainer)this.GetNode("HBoxContainer/SecondTree/PersonList");
        StreetLibrary = (VBoxContainer)this.GetNode("HBoxContainer/SecondTree/StreetsList");
        PersonLibrary.Visible = false;
        StreetLibrary.Visible = false;
		PersonLibrary.Scale = Vector2.Zero;
        StreetLibrary.Scale = Vector2.Zero;
        tween = GetTree().CreateTween();
        
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void PersonLibraryOpen()
	{
        if (PersonLibrary.Visible != true) 
        { 
            tween.TweenProperty(PersonLibrary, "scale", new Vector2(1, 1), 0.2f);
            PersonLibrary.Visible = true;
	        StreetLibrary.Visible = false;
        }
    }
	public void StreetsLibraryOpen()
	{
        if (StreetLibrary.Visible != true)
        {
            tween.TweenProperty(StreetLibrary, "scale", new Vector2(1, 1), 0.2f);
            PersonLibrary.Visible = false;
            StreetLibrary.Visible = true;
        }
    }
}
