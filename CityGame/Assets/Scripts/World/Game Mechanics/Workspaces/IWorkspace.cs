using System;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"> ProjectID</typeparam>
/// <typeparam name="S"> ProjectSpaceID</typeparam>
public interface IWorkspace 
{

    public void CheckForAvailableJobs();
    public ICityProjectTicket GetProjectTicket(SkillController skillController);
    public Scenes GetSceneLocation();


    //Events
    public delegate void ProjectQueueUpdated();
    public event ProjectQueueUpdated OnProjectQueueUpdated;

}
