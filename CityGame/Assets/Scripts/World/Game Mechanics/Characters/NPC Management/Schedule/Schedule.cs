using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Schedule : MonoBehaviour
{
    //Foreign Components
    private CharacterController characterController;

    [SerializeField] private PathAndFileName pathAndFileName_ScheduleInfo;
    [SerializeField] private ScheduleInformation scheduleInformation;


    private Stack<ScheduleEvent> currentSchedule;
    [SerializeField] private ScheduleEvent currentEvent;

    private void Awake()
    {
        scheduleInformation.DeserializeInformation(pathAndFileName_ScheduleInfo);
    }

    private IEnumerator Start()
    {
        characterController = GetComponentInParent<CharacterController>();
        yield return new WaitForSeconds(.1f);
        SetCurrentSchedule();
    }

    private void OnDestroy()
    {
        scheduleInformation.SerializeInformation(pathAndFileName_ScheduleInfo);
    }

    public bool UpdateCurrentEvent(TimeStamp currentTime)
    {
        if (CurrentSchedule.Count > 0 && CurrentSchedule.Peek() != null)
        {
            if (currentTime.IsSameTime(CurrentSchedule.Peek().StartTime))
            {
                CurrentEvent = CurrentSchedule.Pop();
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
    
    public void SetCurrentSchedule()
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

        
}
