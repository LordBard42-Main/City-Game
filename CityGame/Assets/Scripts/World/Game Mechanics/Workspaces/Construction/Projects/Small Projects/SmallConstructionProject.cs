using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSmallProject", menuName = "Workspaces/Construction/Small Project")]
public class SmallConstructionProject : ConstructionProject
{


    protected override void OnValidate()
    {
        base.OnValidate();
        projectSize = ProjectSize_IDs.Small;
    }

}
