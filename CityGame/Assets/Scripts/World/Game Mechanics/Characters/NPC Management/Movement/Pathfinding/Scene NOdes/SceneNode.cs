using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Describes which scenes are neighbors to wich scenes
/// </summary>
[CreateAssetMenu(fileName ="sceneNode", menuName = "Pathing Manager/Scene Nodes")]
public class SceneNode : ScriptableObject, IComparable<SceneNode>
{
    [SerializeField] private int numberOfNeighbors;
    private int distance;
    [SerializeField] private Scenes scene;
    [SerializeField] [HideInInspector] private SceneNodeWrapper[] neighbors;

    public int Distance { get => distance; set => distance = value; }
    public SceneNodeWrapper[] Neighbors { get => neighbors; set => neighbors = value; }
    public Scenes Scene { get => scene; set => scene = value; }

    public int CompareTo(SceneNode other)
    {

        return this.distance.CompareTo(other.Distance);
    }

    private void OnValidate()
    {

        if (neighbors.Length != numberOfNeighbors)
        {
            Array.Resize(ref neighbors, numberOfNeighbors);
        }

    }
}

[CustomEditor(typeof(SceneNode))]
[CanEditMultipleObjects]
public class SceneNodeEditor : Editor
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
        if (flag)
        {
            foreach (SerializedProperty field in list)
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
public class SceneNodeWrapper
{

    public SceneNode currentNode;
    public SceneNodeWrapper previousNode;
    public float distance;

    public SceneNodeWrapper(SceneNode currentNode, SceneNodeWrapper previousNode, float distance)
    {
        this.currentNode = currentNode;
        this.previousNode = previousNode;
        this.distance = distance;
    }

    public SceneNodeWrapper(SceneNode currentNode)
    {
        this.currentNode = currentNode;

    }
}
