using AllMentalGodot.Assets.Entity;
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
	ItemList Health;

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
		Health = (ItemList)this.GetNode("HBoxContainer/VBoxContainer/Health/ItemList");
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
		GD.Print("Alive:"+!person.Dead + " Conscious:" + person.Conscious);
        person.Body.KnifeHitWound();
     


    }
	
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (personId != default(Guid)){
            DateOfDeath.Text = PlayerInfo.CurrentCity.Population[personId].DateOfDeath.ToString("f");
            Location.Text = PlayerInfo.CurrentCity.Population[personId].CurrentLocation.Adress;
			var person = PlayerInfo.CurrentCity.Population[personId];

            Health.Clear();
            Health.AddItem($"Blood amount: {(float)person.Body.ActualBloodAmount / (float)person.Body.MaxBloodAmount * 100} %");
            Health.AddItem($"Blood pressure: {(float)person.Body.ActualBloodPressure / (float)person.Body.MaxBloodPressure * 100} %");
            Health.AddItem($"Breathing rate: {(float)person.Body.ActualRespiratoryRate / (float)person.Body.MaxRespiratoryRate * 100} %");
            foreach (var _person in person.Body.BodyPathsList)
                foreach (var trauma in _person.ActiveStatus)
                {
                    Health.AddItem(trauma.Name);
                }

        }

    }
}



