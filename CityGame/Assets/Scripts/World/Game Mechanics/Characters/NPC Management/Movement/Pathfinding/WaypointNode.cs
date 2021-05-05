using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "waypointNode", menuName = "Pathing Manager/Waypoint Node")]
public class WaypointNode : ScriptableObject
{
    public Vector2 location;
    [SerializeField] private int numberOfNeighbors;
    [SerializeField] [HideInInspector] private WaypointNodeWrapper[] neighbors;
    [SerializeField] private Scenes leadsTo;

    public float distance { get; set; }
    public WaypointNodeWrapper[] Neighbors { get => neighbors; set => neighbors = value; }
    public Scenes LeadsTo { get => leadsTo; set => leadsTo = value; }

    private void OnValidate()
    {

        if (Neighbors.Length != numberOfNeighbors)
        {
            Array.Resize(ref neighbors, numberOfNeighbors);
        }

    }
}

[CustomEditor(typeof(WaypointNode))]
[CanEditMultipleObjects]
public class WaypointNodeEditor : Editor
{
    SerializedProperty list;
    SerializedProperty size;
    bool flag = true;

    private void OnEnable()
    {
        list = serializedObject.FindProperty("neighbors");
        size = serializedObject.FindProperty("numberOfNeighbors");
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        flag = EditorGUILayout.BeginFoldoutHeaderGroup(flag, "Neighbors");
        int i = 0;
        if(flag)
        {
            foreach(SerializedProperty field in list)
            {
                EditorGUILayout.PropertyField(field.FindPropertyRelative("currentNode"), new GUIContent(i + ""));
                i++;
            }

        }

        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorUtility.SetDirty(this);
        serializedObject.ApplyModifiedProperties();


    }
}


[System.Serializable]
public class WaypointNodeWrapper{

    public WaypointNode currentNode;
    public WaypointNodeWrapper previousNode;
    public float distance;

    public WaypointNodeWrapper(WaypointNode currentNode, WaypointNodeWrapper previousNode, float distance)
    {
        this.currentNode = currentNode;
        this.previousNode = previousNode;
        this.distance = distance;
    }

    public WaypointNodeWrapper(WaypointNode currentNode)
    {
        this.currentNode = currentNode;

    }
}