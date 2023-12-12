using Godot;
using System;

public partial class ProfileFullUI : Window
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Open(string id)
	{
		GD.Print(id);
		this.Show();
		Guid guid = Guid.Parse(id);
	}
	private void _on_close_requested()
	{
		this.Hide();
	}
}



