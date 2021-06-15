using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class TimeStamp
{


    [SerializeField] private int hours;
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    public int Hours { get => hours; set => hours = value; }
    public int Minutes { get => minutes; set => minutes = value; }
    public int Seconds { get => seconds; set => seconds = value; }

    [JsonConstructor]
    public TimeStamp(int hours, int minutes)
    {
        this.hours = hours;
        this.minutes = minutes;
        seconds = 0;
    }
    public TimeStamp(int hours, int minutes, int seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public override string ToString()
    {
        return "Time: " + hours + ":" + minutes + "." + seconds;
    }

    public bool IsSameTime(TimeStamp newTime)
    {
        return hours == newTime.Hours && minutes == newTime.Minutes;
    }

}

// IngredientDrawer
[CustomPropertyDrawer(typeof(TimeStamp))]
public class TimeStampDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var hourLabelRect = new Rect(position.x - 15, position.y, position.width / 3, 17);
        var hoursRect = new Rect(position.x, position.y, position.width/3, 17);

        var minuteLabelRect = new Rect(position.x + 5 + position.width / 3, position.y, position.width / 3, 17);
        var minuteRect = new Rect(position.x + 22 + position.width/3, position.y, position.width / 3, 17);
        //var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.LabelField(hourLabelRect, "H:");
        EditorGUI.PropertyField(hoursRect, property.FindPropertyRelative("hours"), GUIContent.none);
        EditorGUI.LabelField(minuteLabelRect, "M:");
        EditorGUI.PropertyField(minuteRect, property.FindPropertyRelative("minutes"), GUIContent.none);
        //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("seconds"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

}