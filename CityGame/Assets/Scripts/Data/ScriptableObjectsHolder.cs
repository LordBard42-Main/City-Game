using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;


public class ScriptableObjectsHolder : MonoBehaviour
{
    public static ScriptableObjectsHolder instance;

    public CityProjectsSOHolder cityProjectsHolder;

    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Debug.LogWarning("SO OBjects Holder Already Exists");
            Destroy(this);
            return;
        }

        instance = this;

    #endregion

    }

}
