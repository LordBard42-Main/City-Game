using System;
using UnityEngine;

public interface ICityProjectTicket
{

    public void SetProject<T>(T project) where T : Enum;
    public void SetProjectSpace<T>(T projectID) where T : Enum;

    public CityProjectSpace GetCityProjectSpace();
    public CityProject GetCityProject();

    public Scenes GetDestinationScene();
    public Vector2 GetDestinationPosition();

}
