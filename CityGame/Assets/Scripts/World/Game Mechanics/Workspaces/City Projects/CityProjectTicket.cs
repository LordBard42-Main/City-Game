using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CityProjectTicket
{

    [SerializeField] [HideInInspector] private readonly string name = "CityProjectTicket";


    [Header("City Project Information")]
    [SerializeField] private CityProjectSpaceHolder cityProjectSpace;
    [SerializeField] protected CityProjectHolder cityProjectHolder;
    [SerializeField] protected float amountOfWorkComplete;

    public CityProjectTicket(CityProjectSpaceHolder cityProjectSpace, CityProjectHolder cityProjectHolder)
    {
        this.cityProjectSpace = cityProjectSpace;
        this.cityProjectHolder = cityProjectHolder;
    }

    public CityProjectSpaceHolder CityProjectSpaceHolder { get => cityProjectSpace;}
    public CityProjectHolder CityProjectHolder { get => cityProjectHolder;}
    public float AmountOfWorkComplete { get => amountOfWorkComplete; set => amountOfWorkComplete = value; }
}