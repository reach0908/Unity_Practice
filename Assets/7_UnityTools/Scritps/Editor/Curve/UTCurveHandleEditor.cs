using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor(typeof(UTCurveHandle))]
public class UTCurveHandleEditor : Editor
{

//void Repaint()
   
   void OnSceneGUI ()
   {
      // Refresh positions
      ((UTCurveHandle)target).m_HandlePosition1 = 
         Handles.PositionHandle (((UTCurveHandle)target).m_HandlePosition1, Quaternion.identity);
      
      ((UTCurveHandle)target).m_HandlePosition2 = 
         Handles.PositionHandle (((UTCurveHandle)target).m_HandlePosition2, Quaternion.identity);
      
      ((UTCurveHandle)target).m_HandlePosition3 = 
         Handles.PositionHandle (((UTCurveHandle)target).m_HandlePosition3, Quaternion.identity);
      
      // Draw Bezier curve
      float width = HandleUtility.GetHandleSize(Vector3.zero) * 0.1f;
      
      Debug.Log(width);
      
      Vector3 tangent1 = 
         ((UTCurveHandle)target).m_HandlePosition2 - ((UTCurveHandle)target).m_HandlePosition1;
      Vector3 tangent2 = 
         ((UTCurveHandle)target).m_HandlePosition3 - ((UTCurveHandle)target).m_HandlePosition1;
      Vector3 tangent3 = 
         ((UTCurveHandle)target).m_HandlePosition3 - ((UTCurveHandle)target).m_HandlePosition2;
      
      tangent1 = tangent1.normalized;
      tangent2 = tangent2.normalized;
      tangent3 = tangent3.normalized;
      
      
      Handles.DrawBezier(((UTCurveHandle)target).m_HandlePosition1,
                         ((UTCurveHandle)target).m_HandlePosition2,
                         tangent1 ,
                         -tangent2 ,
                         Color.red,
                         null,
                         width);
      
      Handles.DrawBezier(((UTCurveHandle)target).m_HandlePosition2,
                         ((UTCurveHandle)target).m_HandlePosition3,
                         tangent2 ,
                         -tangent3 ,
                         Color.red,
                         null,
                         width);
      
      
      if (GUI.changed) {
         EditorUtility.SetDirty (target);
      }
   }
}
