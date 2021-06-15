using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CityProjectHolder
{


    [SerializeField]
    [BoxGroup("Dynamic Data")]
    [LabelWidth(100)]
    private bool workReady;

    [JsonProperty]
    public bool WorkReady { get => workReady; set => workReady = value; }
}
