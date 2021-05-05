using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarDay : MonoBehaviour
{
    [SerializeField] private Text date;
    public int cellIndex;


    private void Start()
    {
        cellIndex = (transform.GetSiblingIndex() + 1);
        date.text = "" + cellIndex;
    }
}
