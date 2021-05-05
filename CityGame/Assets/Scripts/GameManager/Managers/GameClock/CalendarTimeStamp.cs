using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CalendarTimeStamp
{

    [SerializeField] private int day;
    [SerializeField] private int hours;
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    public int Day { get => day; set => day = value; }
    public int Hours { get => hours; set => hours = value; }
    public int Minutes { get => minutes; set => minutes = value; }
    public int Seconds { get => seconds; set => seconds = value; }

    public CalendarTimeStamp(int day, int hours, int minutes, int seconds)
    {
        this.day = day;
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public override string ToString()
    {
        return "Time: " + day + ":" + hours + ":" + minutes + "." + seconds;
    }

}
