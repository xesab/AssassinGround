using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypintManagerWindow : EditorWindow
{
    [MenuItem("Waypoint/Waypoint Editor Tools")]
    public static void ShowWindow()
    {
        GetWindow<WaypintManagerWindow>("Waypoint Editor tools");
    }

    public Transform waypointOrigin;

    void Creatbuttons()
    {
        if(GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }

    }
    void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointOrigin.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointOrigin,false);

        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();

        if(waypointOrigin.childCount > 1)
        {
            waypoint.previousWaypoint = waypointOrigin.GetChild(waypointOrigin.childCount - 2).GetComponent<Waypoint>();
            waypoint.previousWaypoint.nextWaypoint = waypoint;

            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }
        Selection.activeGameObject = waypoint.gameObject;
    }

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigin"));

        if(waypointOrigin == null)
        {
            EditorGUILayout.HelpBox("Please assign a Waypoiny Origin transform.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            Creatbuttons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }
    
}
