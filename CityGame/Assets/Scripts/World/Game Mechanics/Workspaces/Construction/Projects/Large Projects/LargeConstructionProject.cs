using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewLargeProject", menuName = "Workspaces/Construction/Large Project")]
public class LargeConstructionProject : ConstructionProject
{

    protected override void OnValidate()
    {
        base.OnValidate();
        projectSize = ProjectSize_IDs.Large;
    }

}
