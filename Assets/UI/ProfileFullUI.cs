using Engine.PlayerEngine;
using Godot;
using System;

public partial class ProfileFullUI : Window
{
	Label PersonName;
	Label PersonAge;
	public override void _Ready()
	{
		PersonName = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer/Name");
		PersonAge = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer/Age");
		this.Hide();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Open(string id)
	{
		GD.Print(id);
		this.Show();
		Guid guid = Guid.Parse(id);
		var person = PlayerInfo.CurrentCity.Population[guid];
		PersonName.Text = person.FirstName + " " + person.SecondName;
		PersonAge.Text = "Age:" + person.Age;
	}
	private void _on_close_requested()
	{
		this.Hide();
	}
}



