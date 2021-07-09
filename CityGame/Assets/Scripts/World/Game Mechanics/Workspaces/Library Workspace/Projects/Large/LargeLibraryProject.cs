using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LargeLibraryProject", menuName = "Workspaces/Library/Large Project")]
public class LargeLibraryProject : LibraryProject
{


    private void OnValidate()
    {
        projectSize = ProjectSizes.Large;
    }
}
