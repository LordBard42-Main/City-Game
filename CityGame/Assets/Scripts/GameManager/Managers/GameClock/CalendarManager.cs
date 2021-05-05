using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{

    #region Singleton
    public static CalendarManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of CalendarManager" +
                " found");
            return;
        }

        instance = this;
    }
    #endregion

    public GameObject calendarUI;
    GameManager gameManager;
    GameClock gameClock;

    [SerializeField] private Transform calendarDayParent;
    [SerializeField] private Text calendarDayText;
    private CalendarDay[] calendarDays;
    private CalendarDay currentCalendarDay;

    public int currentDay { get; set;}

    private void Start()
    {
        gameManager = GameManager.instance;
        gameClock = GameClock.instance;
        gameClock.OnDay += UpdateDay;

        calendarDays = calendarDayParent.GetComponentsInChildren<CalendarDay>();
        currentCalendarDay = calendarDays[0];
    }

    public void UpdateDay()
    {

        currentCalendarDay.GetComponent<Image>().color = new Color(1f, 1f, 1f);

        currentDay++;
        currentCalendarDay = calendarDays[currentDay];
        currentCalendarDay.GetComponent<Image>().color = new Color(.5f, .5f, .5f);
        calendarDayText.text = currentDay + 1 + "";
    }

    public void OpenCalendar()
    {
        calendarUI.SetActive(true);
    }

    public CalendarTimeStamp GetCalendarTimeStamp()
    {
        CalendarTimeStamp currentTimeStamp = new CalendarTimeStamp(currentDay, gameClock.Hours, gameClock.Minutes, gameClock.Seconds);
        return currentTimeStamp;
    }
}
