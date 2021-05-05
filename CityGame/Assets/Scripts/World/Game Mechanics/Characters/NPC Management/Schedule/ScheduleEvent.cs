using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventTypes { None, Work, Lunch, FreeTime}
[System.Serializable]
public class ScheduleEvent 
{
    [SerializeField] private string eventType;
    [SerializeField] private TimeStamp startTime;


    public EventTypes GetEventType()
    {
        return (EventTypes)Enum.Parse(typeof(EventTypes), eventType);
    }

    public TimeStamp StartTime { get => startTime; private set => startTime = value; }

}
