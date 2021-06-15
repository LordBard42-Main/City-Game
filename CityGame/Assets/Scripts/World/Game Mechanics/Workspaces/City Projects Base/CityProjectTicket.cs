using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

[System.Serializable]
public class CityProjectTicket
{

    [SerializeField]
    [BoxGroup("Static Data")]
    [LabelWidth(100)]
    private float progress;

    [JsonProperty]
    public float Progress { get => progress; set => progress = value; }
}
