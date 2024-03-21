using Engine.PlayerEngine;
using Godot;
using System;

public partial class RunTimeScriptEngine : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _EnterTree()
    {
        base._EnterTree();
        PlayerInfo.Init();
        PlayerInfo.CityLive.Start();
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
