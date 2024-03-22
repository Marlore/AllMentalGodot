using Godot;
using System;

public partial class StreetsButton : Button
{
    public string StreetId;
    public void UpdateId(string id) => StreetId = id;    

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
