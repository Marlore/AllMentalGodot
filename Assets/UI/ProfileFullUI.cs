using Data.Appartment;
using Engine.PlayerEngine;
using Entity.Company;
using Entity.People;
using Godot;
using System;

public partial class ProfileFullUI : Window
{
	Label PersonName;
	Label PersonAge;
	Label Location;
	Label Work;

	ItemList Contacts;
	ItemList Events;

	Guid personId;
	public override void _Ready()
	{
		Location = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer2/Location");
        PersonName = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer/Name");
		PersonAge = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer/Age");
		Work = (Label)this.GetNode("Control/HBoxContainer/VBoxContainer2/Work");

        Contacts = (ItemList)this.GetNode("Control/HBoxContainer/VBoxContainer/Control/ItemList");
        Events = (ItemList)this.GetNode("Control/HBoxContainer/VBoxContainer2/EventControl/Events");
		
        this.Hide(); 
		
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Open(string id)
	{
		int indexContacts= 0;
       
        this.Show();
		Guid guid = Guid.Parse(id);
        personId = guid;
        var person = PlayerInfo.CurrentCity.Population[guid];
        PersonName.Text = person.FirstName + " " + person.SecondName;
		PersonAge.Text = "Age:" + person.Age +"     " +person.Plans.Count;
		Contacts.Clear();
		foreach(var contact in person.Contacts)
			Contacts.AddItem($"Relationships with {contact.Key.FirstName} {contact.Key.SecondName} is {contact.Value}", null, true);
		Events.Clear();
        foreach (var plan in person.Plans)
            Events.AddItem($" from {plan.Value.PlannedDate} to {plan.Value.PlannedDate.AddMinutes(plan.Value.Duration)} {plan.Key}", null, true);
		Work.Text = person.Job.Name;
		
        
    }
	private void _on_close_requested()
	{
		this.Hide();
	}
    public override void _Process(double delta)
    {
		if (personId != default(Guid)){
            Location.Text = PlayerInfo.CurrentCity.Population[personId].CurrentLocation.Adress;

            GD.Print(PlayerInfo.CurrentCity.Population[personId]._intermediateSegment);
        }
        base._Process(delta);
    }
}



