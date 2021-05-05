using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsumablePrefabHolder : PrefabsHolder
{
    [Header("Consumables")]
    [SerializeField] private Transform blueBerry;
    [SerializeField] private Transform cherry;
    [SerializeField] private Transform baseMixture;
    [SerializeField] private Transform cherryMuffin;
    [SerializeField] private Transform sprinkles;
    [SerializeField] private Transform blueBerryMuffin;


    //Consumables
    public Transform BlueBerry { get => blueBerry; set => blueBerry = value; }
    public Transform Cherry { get => cherry; set => cherry = value; }
    public Transform BaseMixture { get => baseMixture; set => baseMixture = value; }
    public Transform CherryMuffin { get => cherryMuffin; set => cherryMuffin = value; }
    public Transform Sprinkles { get => sprinkles; set => sprinkles = value; }
    public Transform BlueBerryMuffin { get => blueBerryMuffin; set => blueBerryMuffin = value; }


}
