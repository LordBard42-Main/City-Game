using System.Collections;
using UnityEngine;

public interface UIInterface
{
    GameObject GetCanvasObject();
    GameObject GetCreatedCanvas();

    void CreateCanvas();

    void DestroyCanvas();

}
