using Godot;
using System;

public partial class PersonButton : Button
{

	public string PersonId;
	public void UpdateId(string id)=> PersonId = id;
	private void _on_pressed()
	{
		Window window = (Window)this.GetTree().Root.GetNode("MainDesk/ProfileFull");
		window.Call("Open", PersonId);
	}
}



