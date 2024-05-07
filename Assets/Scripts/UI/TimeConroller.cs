using Data.CityData;
using Engine.PlayerEngine;
using Godot;
using System;

public partial class TimeConroller : HBoxContainer
{
    public void _on_first_speed_pressed()
    {
        PlayerInfo.CurrentCity.Time.timeScale = (int)TimeScaleTick.first;
    }
    public void _on_second_speed_pressed()
    {
        PlayerInfo.CurrentCity.Time.timeScale = (int)TimeScaleTick.second;
    }
    public void _on_third_speed_pressed()
    {
        PlayerInfo.CurrentCity.Time.timeScale = (int)TimeScaleTick.third;
    }
    public void _on_pause_pressed()
    {
        if (PlayerInfo.CurrentCity.Time.Paused)
        {
            PlayerInfo.CurrentCity.TimeScaleEvent.Reset();
            PlayerInfo.CurrentCity.Time.Paused=false;
        }
        else
        {
            PlayerInfo.CurrentCity.TimeScaleEvent.Set();
            PlayerInfo.CurrentCity.Time.Paused = true;
        }
    }
}
