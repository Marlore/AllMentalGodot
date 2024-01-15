using Engine.PlayerEngine;
using Godot;
using System;

public partial class ProfileFullUI : Window
{
	Label PersonName;
	Label PersonAge;
	ItemList Contacts;
	public override void _Ready()
	{
		PersonName = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer/Name");
		PersonAge = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer/Age");
        Contacts = (ItemList)this.GetNode("Control/HBoxContainer/VBoxContainer/Control/ItemList");
        this.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Open(string id)
	{
		this.Show();
		Guid guid = Guid.Parse(id);
		var person = PlayerInfo.CurrentCity.Population[guid];
		PersonName.Text = person.FirstName + " " + person.SecondName;
		PersonAge.Text = "Age:" + person.Age +"     " +person.Plans.Count;
		Contacts.Clear();
		foreach(var contact in person.Contacts)
		{
			Contacts.AddItem($"Relationships with {contact.Key.FirstName} {contact.Key.SecondName} is {contact.Value}", null, true);
		}
	}
	private void _on_close_requested()
	{
		this.Hide();
	}
    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}



