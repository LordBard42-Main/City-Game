using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class UIController : UIInterface
{
    
    [SerializeField] private GameObject canvasPrefab;

    private GameObject createdCanvas;


    public void CreateCanvas()
    {
        createdCanvas = Object.Instantiate(canvasPrefab);
    }

    public void DestroyCanvas()
    {
        if (createdCanvas != null)
            Object.Destroy(createdCanvas);
        
        
    }

    public GameObject GetCanvasObject()
    {
        return canvasPrefab;
    }

    public GameObject GetCreatedCanvas()
    {
        return createdCanvas;
    }
}
