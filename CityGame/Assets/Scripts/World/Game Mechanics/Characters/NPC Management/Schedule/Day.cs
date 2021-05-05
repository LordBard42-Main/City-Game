using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Day
{
    [SerializeField] private List<ScheduleEvent> events;

    public List<ScheduleEvent> Events { get => events; private set => events = value; }
}
