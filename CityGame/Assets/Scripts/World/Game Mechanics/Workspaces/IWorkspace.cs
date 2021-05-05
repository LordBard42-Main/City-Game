using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkspace
{
    void InitializeWorkspace();
    List<CityProject> GetProjectsBySkillLevel(ProjectSize_IDs size);

    List<CityProject> GetObjectsOfSkillLevel(ProjectSize_IDs size, int level);

    List<CityProject> GetObjectsBetweenSkillLevels(ProjectSize_IDs size, int floor, int ceiling);


}
