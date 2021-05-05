using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMediumProject", menuName = "Workspaces/Construction/Medium Project")]
public class MediumConstructionProject : ConstructionProject
{


    protected override void OnValidate()
    {
        base.OnValidate();
        projectSize = ProjectSize_IDs.Medium;
    }
}
