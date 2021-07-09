using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SmallLibraryProject", menuName = "Workspaces/Library/Small Project")]
public class SmallLibraryProject : LibraryProject
{


    private void OnValidate()
    {
        projectSize = ProjectSizes.Small;
    }
}
