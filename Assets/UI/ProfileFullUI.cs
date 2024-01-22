using Engine.PlayerEngine;
using Godot;
using System;

public partial class ProfileFullUI : Window
{
	Label PersonName;
	Label PersonAge;
	ItemList Contacts;
	ItemList Events;
	public override void _Ready()
	{
		PersonName = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer/Name");
		PersonAge = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer/Age");
        Contacts = (ItemList)this.GetNode("Control/HBoxContainer/VBoxContainer/Control/ItemList");
        Events = (ItemList)this.GetNode("Control/HBoxContainer/VBoxContainer2/EventControl/Events");
        this.Hide(); 
		
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Open(string id)
	{
		int indexContacts= 0;
        for (int i = 0; i < 0; i++)
        {
            GD.Print("First");
        }
        this.Show();
		Guid guid = Guid.Parse(id);
		var person = PlayerInfo.CurrentCity.Population[guid];
		PersonName.Text = person.FirstName + " " + person.SecondName;
		PersonAge.Text = "Age:" + person.Age +"     " +person.Plans.Count;
		Contacts.Clear();
		foreach(var contact in person.Contacts)
			Contacts.AddItem($"Relationships with {contact.Key.FirstName} {contact.Key.SecondName} is {contact.Value}", null, true);
		Events.Clear();
        foreach (var plan in person.Plans)
            Events.AddItem($" from {plan.Value.PlannedDate} to {plan.Value.PlannedDate.AddMinutes(plan.Value.Duration)} {plan.Key}", null, true);
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



