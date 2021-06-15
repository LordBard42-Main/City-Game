using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectSpaceController : MonoBehaviour
{

    private CityProjectSpace cityProjectReference;


    [Header("Project Space Componenets")]
    [SerializeField] private Slider progresSlider;

    public Slider ProgresSlider { get => progresSlider; set => progresSlider = value; }

    private void Awake()
    {
    }

}
