using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestingCustomEditor : MonoBehaviour
{
    public bool flag;
    public int i = 1;

    public bool flag2;
    public int a = 1;
    public int b = 1;

    public bool flag3;
    public string status = "Foldout here";
    public int c = 1;
    public int d = 1;
    public int e = 1;


    private void Update()
    {
        Debug.Log(i);
    }
}

[CustomEditor(typeof(TestingCustomEditor))]
public class MyScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ///This refrences the script being edited.
        var myScript = target as TestingCustomEditor;



        ///This is a custom Toggle to hide fields
        myScript.flag = GUILayout.Toggle(myScript.flag, "Flag");
        if (myScript.flag)
        {
            myScript.i = EditorGUILayout.IntSlider("I field:", myScript.i, 1, 100);
            ///This is a custom Script Field
           
        }


        ///This is a Custom Drop Down containing fields
        EditorGUILayout.LabelField(myScript.status);
        myScript.flag3 = EditorGUILayout.BeginFoldoutHeaderGroup(myScript.flag3, myScript.status);
        if (myScript.flag3)
            if (Selection.activeTransform)
            {
                myScript.c = EditorGUILayout.IntField(myScript.c);
                myScript.d = EditorGUILayout.IntField(myScript.d);

                //myScript.status = Selection.activeTransform.name;
            }

        if (!Selection.activeTransform)
        {
            myScript.status = "Select a GameObject";
            myScript.flag3 = false;
        }
        EditorGUI.EndFoldoutHeaderGroup();

        

        ///This is a custom toggle group, it greys it out instead of hiding it
        myScript.flag2 = EditorGUILayout.BeginToggleGroup("Set Letters", myScript.flag2);
        myScript.a = EditorGUILayout.IntField(myScript.a);
        myScript.b = EditorGUILayout.IntField(myScript.b);
        EditorGUILayout.EndToggleGroup();


    }
}





// Creates an instance of a primitive depending on the option selected by the user.

public enum OPTIONS
{
    CUBE = 0,
    SPHERE = 1,
    PLANE = 2
}

public class EditorGUILayoutEnumPopup : EditorWindow
{
    private Dictionary<int, string> dict = new Dictionary<int, string>();

    [SerializeField] private string a = "Anchor";
    [SerializeField] private string b = "Bellows";
    [SerializeField] private string c = "Chalice";

    [ReadOnly]
    [SerializeField] private string field;

    [MenuItem("Examples/Editor GUILayout Enum Popup usage")]
    static void Init()
    {
        UnityEditor.EditorWindow window = GetWindow(typeof(EditorGUILayoutEnumPopup));
        window.Show();
    }

    void OnGUI()
    {
        if (dict != null)
            dict.Clear();

        dict.Add(1, a);
        dict.Add(2, b);
        dict.Add(3, c);

        a = EditorGUILayout.TextField("A(1):", a);
        b = EditorGUILayout.TextField("B(2):", b);
        c = EditorGUILayout.TextField("C(3):", c);

        field = EditorGUILayout.TextField("Field:", field);

        if (GUILayout.Button("Get Dict[2]"))
            field = dict[Random.Range(1, 4)];

    }

}