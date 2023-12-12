using Godot;
using System;

public partial class PersonButton : Button
{


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private void _on_pressed()
	{
		Window window = (Window)this.GetTree().Root.GetNode("MainDesk/ProfileFull");
		window.Call("Open", this.Name);
	}
}



