using Data.Appartment;
using Engine.PlayerEngine;
using Entity.Company;
using Entity.People;
using Godot;
using Scripts.Entity.TraumaEntity;
using System;

public partial class ProfileFullUI : VBoxContainer
{
	Label PersonName;
	Label PersonAge;
	Label Location;
	Label Work;
	Label DateOfDeath;

	ItemList Contacts;
	ItemList Events;

	Guid personId;
	public override void _Ready()
	{
		Location = (Label)this.GetNode("HBoxContainer/VBoxContainer2/Location");
        PersonName = (Label)this.GetNode("HBoxContainer/VBoxContainer/Name");
		PersonAge = (Label)this.GetNode("HBoxContainer/VBoxContainer/Age");
		Work = (Label)this.GetNode("HBoxContainer/VBoxContainer2/Work");
		DateOfDeath = (Label)this.GetNode("HBoxContainer/VBoxContainer/DateOfBith");

        Contacts = (ItemList)this.GetNode("HBoxContainer/VBoxContainer/Control/ItemList");
		Events = (ItemList)this.GetNode("HBoxContainer/VBoxContainer2/EventControl/Events");

		this.Hide();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void Open(string id)
	{
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
            Events.AddItem($" from {plan.Value.PlannedDate} to {plan.Value.PlannedDate.AddMinutes(plan.Value.Duration)}", null, true);
		Work.Text = person.Job.Name;
        GD.Print(person.Health.ActualBloodDrain);
        //foreach (var trauma in person.Health.torso.Condition)
			

    }
	
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (personId != default(Guid)){
            DateOfDeath.Text = PlayerInfo.CurrentCity.Population[personId].DateOfDeath.ToString("f");
            Location.Text = PlayerInfo.CurrentCity.Population[personId].CurrentLocation.Adress;
            //GD.Print(PlayerInfo.CurrentCity.Population[personId]._intermediateSegment.Adress);
        }

    }
}



