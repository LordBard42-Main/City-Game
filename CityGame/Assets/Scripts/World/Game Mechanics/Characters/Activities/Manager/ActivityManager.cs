using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour
{
    public static ActivityManager instance;

    [SerializeField] private List<LunchActivity> lunchActivities;

    private void Awake()
    {

        #region Singleton
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ActivityManager found");
            Destroy(gameObject);
            return;
        }

        instance = this;
        #endregion

    }


    public Activity GetActivityByEventTypes(EventTypes type)
    {
        switch (type)
        {
            
            case EventTypes.Lunch:
                return lunchActivities[0];
            case EventTypes.FreeTime:
                break;
            default:
                break;
        }

        return default(Activity);
    }

}
