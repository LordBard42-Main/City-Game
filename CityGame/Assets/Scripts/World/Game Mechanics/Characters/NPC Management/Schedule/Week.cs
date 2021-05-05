using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Week
{

    [SerializeField] private Day jobSchedule;
    [SerializeField] private Day joblessSchedule;

    public Day JobSchedule { get => jobSchedule; set => jobSchedule = value; }
    public Day JoblessSchedule { get => joblessSchedule; set => joblessSchedule = value; }
}
