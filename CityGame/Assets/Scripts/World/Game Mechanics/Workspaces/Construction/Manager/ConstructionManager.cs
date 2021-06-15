using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ConstructionManager : Workspace
{ 
    public static ConstructionManager instance;


    protected override void Awake()
    {
        #region  Singleton
        if (instance != null)
        {
            Debug.LogWarning("CityManagement already exists");
            return;
        }
        instance = this;
        #endregion

        base.Awake();


    }

    private void Start()
    {
    }


}

