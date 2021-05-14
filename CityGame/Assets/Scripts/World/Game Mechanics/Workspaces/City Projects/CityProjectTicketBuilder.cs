using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CityProjectTicketBuilder
{
 
    public static CityProjectTicket CreateSmallProjectTicket(Workspace workspace)
    {
        CityProjectTicket cityProjectTicket;

        foreach (CityProjectSpaceHolder projectSpaceHolder in workspace.CityProjectSpaces)
        {

            foreach (CityProjectHolder cityProjectHolder in projectSpaceHolder.SmallCityProjects)
            {
                if (cityProjectHolder.NeedsWorked)
                    return cityProjectTicket = new CityProjectTicket(projectSpaceHolder, cityProjectHolder);

                if (workspace.ProjectQueue.Count >= 5)
                    return default(CityProjectTicket);

            }
        }

        return default(CityProjectTicket);
    }


}
