using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WayPointsController))]
public class WaypointEditor : Editor {
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
//        EditorGUILayout.ToggleLeft("Play On Awake", serializedObject.FindProperty("isMoving").boolValue);
        EditorList.Show(serializedObject.FindProperty("waypoints"));
        serializedObject.ApplyModifiedProperties();
    }
    void OnSceneGUI()
    {
        WayPointsController edited = target as WayPointsController;
        //Handles.BeginGUI();
        Transform targetTrans = edited.transform;
        Vector3 oldHandle = Vector3.zero;
        Vector3 newHandle;
        Vector3 modHandle;
        if (edited.waypoints!=null)
        for (int i = 0;i<edited.waypoints.Length;i++)
        {
            newHandle = new Vector3(edited.waypoints[i].x, edited.waypoints[i].y);
            Handles.DrawLine(targetTrans.position+oldHandle, targetTrans.position + newHandle);
            modHandle = Handles.FreeMoveHandle(targetTrans.position + newHandle, 
                Quaternion.identity, 0.04f, Vector3.one * 0.4f, Handles.DotCap) - 
                targetTrans.position;
            oldHandle = newHandle;
            if (modHandle != oldHandle)
            {
                Undo.RecordObject(edited, "Move");
                edited.waypoints[i].x = modHandle.x;
                edited.waypoints[i].y = modHandle.y;
            }
        }
        //Handles.EndGUI();

    }

}
