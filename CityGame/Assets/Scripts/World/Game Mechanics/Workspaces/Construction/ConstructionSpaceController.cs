using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionSpaceController : MonoBehaviour
{
    //Singletons
    ConstructionManager cityManagement;
    

    [SerializeField] private ProjectSpaceID id;
    [SerializeField] private ConstructionSpace projectSpaceDetails;

    [SerializeField] private Slider progresSlider;


    // Start is called before the first frame update
    void Start()
    {
        
    }
}
