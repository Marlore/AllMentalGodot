using Engine.PlayerEngine;
using Godot;

public partial class ProfileShort : VBoxContainer
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        PlayerInfo.Init();
        PlayerInfo.CityLive.Start();
        var personGo = (PackedScene)ResourceLoader.Load("res://obj/Presets/Person.tscn");
        foreach (var person in PlayerInfo.CurrentCity.Population)
        {
            Button but = (Button)personGo.Instantiate();
            but.Text = person.Value.FirstName + " " + person.Value.SecondName;
            but.Call("UpdateId", person.Key.ToString());
            this.AddChild(but);
        }
    }
    private void _on_tree_exited()
    {
        PlayerInfo.CityLive.Abort();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
