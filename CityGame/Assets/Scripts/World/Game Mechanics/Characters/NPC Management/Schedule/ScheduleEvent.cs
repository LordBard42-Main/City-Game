using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventTypes { None, Work, Lunch, FreeTime}
[System.Serializable]
public class ScheduleEvent 
{
    [SerializeField]
    private EventTypes eventType;
    [SerializeField] 
    private TimeStamp startTime;

    public TimeStamp StartTime { get => startTime; set => startTime = value; }
    public EventTypes EventType { get => eventType; set => eventType = value;  }
}
