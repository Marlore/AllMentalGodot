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
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(PeopleShortPanel, "scale", new Vector2(0,1), 0.2f);
        tween.TweenProperty(FullProfiler, "scale", new Vector2(1, 1), 0.2f);
        FullProfiler.SizeFlagsStretchRatio = 1;
        FullProfiler.Call("Open", PersonId);
	}
}



