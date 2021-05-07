using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityProjectTicket
{
    private CityProject project;
    ProjectSpaceController projectSpace;

    public CityProjectTicket(CityProject project, ProjectSpaceController projectSpace)
    {
        this.project = project;
        this.ProjectSpace = projectSpace;
    }

    public CityProject Project { get => project; set => project = value; }
    public ProjectSpaceController ProjectSpace { get => projectSpace; set => projectSpace = value; }
}
