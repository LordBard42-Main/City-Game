using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClock : MonoBehaviour
{

    private float _elapsedTime; // Seconds
    private float _inGameMinutes = 6f; //How many real seconds count as hour in game

    [SerializeField] private int hours = 8;
    [SerializeField] private int minutes = 00;
    [SerializeField] private int seconds = 0;
    private int oldSeconds = 0;
    [SerializeField] private int amPm;
    public Text clockText;


    public int Hours { get => hours; set => hours = value; }
    public int Minutes { get => minutes; set => minutes = value; }
    public int Seconds { get => seconds; set => seconds = value; }
    public int AmPm { get => amPm; set => amPm = value; }
    public float ElapsedTime { get => _elapsedTime; set => _elapsedTime = value; }
    public float InGameMinutes { get => _inGameMinutes; set => _inGameMinutes = value; }

    public delegate void HourlyCallback(TimeStamp currentTime);
    public event HourlyCallback OnHour;

    public delegate void MinutlyCallback();
    public event MinutlyCallback OnMinute;

    public delegate void SecondlyCallback();
    public event SecondlyCallback OnSecond;

    public delegate void DailyCallback();
    public event DailyCallback OnDay;

    #region Singleton
    public static GameClock instance;

    protected void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameClock found");
            Destroy(gameObject);
            return;
        }

        instance = this;
        
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        oldSeconds = seconds;
        if (OnSecond != null)
            OnSecond();

        clockText.text = (hours.ToString() + ":" + string.Format("{0:00}", minutes));
        //RunClock();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RunClock();

    }

    /// <summary>
    /// Handles the Clock 
    /// </summary>
    private void RunClock()
    {
        _elapsedTime += Time.deltaTime;
        seconds = (int)_elapsedTime;

        if (oldSeconds != seconds)
        {
            if(OnSecond != null)
                OnSecond();
            oldSeconds = seconds;
        }

        if (_elapsedTime >= InGameMinutes)
        {
            if (minutes == 50)
            {
                if (hours == 24)
                {
                    hours = 1;
                    minutes = 00;
                    clockText.text = (hours.ToString() + ":" + string.Format("{0:00}", minutes));
                    _elapsedTime = 0;

                    //if (DailyCallback != null)
                        //DailyCallback.Invoke();
                    
                }
                else
                {
                    minutes = 0;
                    hours++;
                    clockText.text = (hours.ToString() + ":" + string.Format("{0:00}", minutes));
                    _elapsedTime = 0;

                    if (OnHour != null)
                        OnHour(GetCurrentTimestamp());
                    
                }
            }
            else
            {
                minutes += 10;
                clockText.text = (hours.ToString() + ":" + string.Format("{0:00}", minutes));
                //Hour Passed. Do Something
                _elapsedTime = 0;

            }
            
            //if (MinutlyCallback != null)
               // MinutlyCallback.Invoke();

        }
    }

    public float CalculateTimeDifferenceInSeconds(TimeStamp timeStamp)
    {
        float timeDifference = 0;

        timeDifference += ((hours - timeStamp.Hours) * (InGameMinutes * 6));
        timeDifference += (((minutes - timeStamp.Minutes )/10) * (InGameMinutes));

        timeDifference += (seconds - timeStamp.Seconds);


        return Mathf.Abs(timeDifference);
    }


    public TimeStamp GetCurrentTimestamp()
    {
        TimeStamp timeStamp = new TimeStamp(hours, minutes, seconds);

        return timeStamp;
    }

    public bool CheckIfCurrentTime(TimeStamp timeStamp)
    {
        return timeStamp.Hours == hours && timeStamp.Minutes == minutes && timeStamp.Seconds == seconds;
    }

    public int GetTimeDifference(TimeStamp timeStamp)
    {
        return ((timeStamp.Hours - hours)*60) + (timeStamp.Minutes - minutes) + (timeStamp.Seconds - seconds);
    }
}
