using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UTAxisHandle))]
public class UTAxisHandleEditor : Editor
{

//void Repaint()
   
   void OnSceneGUI ()
   {
      ((UTAxisHandle)target).m_HandlePosition = 
         Handles.PositionHandle (((UTAxisHandle)target).m_HandlePosition, Quaternion.identity);
      
      if (GUI.changed) {
         EditorUtility.SetDirty (target);
      }
   }
}
