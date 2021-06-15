using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Schedule : MonoBehaviour
{
    //Singletons Managers
    ActivityManager activityManager;

    //Foreign Components
    private CharacterController characterController;

    [SerializeField] private PathAndFileName pathAndFileName_ScheduleInfo;
    [SerializeField] private ScheduleInformation scheduleInformation;


    private Stack<ScheduleEvent> currentSchedule;
    [SerializeField] private ScheduleEvent currentEvent;
    [SerializeField] private Activity currentActivity;

    private void Awake()
    {

        scheduleInformation.DeserializeInformation(pathAndFileName_ScheduleInfo);
    }

    private IEnumerator Start()
    {
        activityManager = ActivityManager.instance;
        characterController = GetComponent<CharacterController>();

        yield return new WaitForSeconds(.1f);
        SetCurrentSchedule();
    }

    private void OnDestroy()
    {
        scheduleInformation.SerializeInformation(pathAndFileName_ScheduleInfo);
    }

    public bool UpdateCurrentEvent(TimeStamp currentTime)
    {
        if (currentSchedule.Count > 0 && currentSchedule.Peek() != null)
        {
            if (currentTime.IsSameTime(currentSchedule.Peek().StartTime))
            {
                currentEvent = CurrentSchedule.Pop();
                currentActivity = activityManager.GetActivityByEventTypes(currentEvent.EventType);

                return true;
            }
            return false;
        }
        else
        {
            Debug.Log("NPC Schedule is null");
            return false;
    
        }
    }
    

    private void SetCurrentSchedule()
    {
        

        if(characterController.EmployeeController.IsEmployed)
        {
            List<ScheduleEvent> events = scheduleInformation.Q1.JobSchedule.Events;
            currentSchedule = new Stack<ScheduleEvent>();

            for (int i = events.Count - 1; i >= 0; i--)
            {
                currentSchedule.Push(events[i]);
            }


        }
        else
        {
            List<ScheduleEvent> events = scheduleInformation.Q1.JoblessSchedule.Events;
            currentSchedule = new Stack<ScheduleEvent>();

            for (int i = events.Count - 1; i >= 0; i--)
            {
                currentSchedule.Push(events[i]);
            }



        }



    }

    public Stack<ScheduleEvent> CurrentSchedule { get => currentSchedule; private set => currentSchedule = value; }
    public ScheduleEvent CurrentEvent { get => currentEvent; private set => currentEvent = value; }
    public Activity CurrentActivity { get => currentActivity; set => currentActivity = value; }
}
