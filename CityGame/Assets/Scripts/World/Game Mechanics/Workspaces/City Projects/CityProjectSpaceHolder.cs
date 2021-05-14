using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CityProjectSpaceHolder
{

    [SerializeField] private CityProjectSpace cityProjectSpace;

    [Header("City Project Variables")]
    [SerializeField] private List<CityProjectHolder> smallCityProjects;

    [SerializeField] private List<CityProjectHolder> largeCityProjects;


    public CityProjectSpace CityProjectSpace { get => cityProjectSpace;}
    public List<CityProjectHolder> SmallCityProjects { get => smallCityProjects;}
    public List<CityProjectHolder> LargeCityProjects { get => largeCityProjects;}
}
