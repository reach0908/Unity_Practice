using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
   public Color m_Color = Color.white;

   public Vector3 m_Vec = Vector3.zero;

   public float m_ScalarMul = 1f;

   public float m_Magnitude;
   public Vector3 m_Direction;


   void OnDrawGizmos()
   {
      Vector3 scaledVector = m_Vec * m_ScalarMul;

      UTGlobalGizmosUtility.DrawArrow(
         transform.position, // world position
         scaledVector,                  // vector
         1f,                         // arrow head scale
         m_Color                 // color
         );

      m_Magnitude = scaledVector.magnitude; // 벡터의 길이.
      m_Direction = scaledVector.normalized; // 벡터의 방향 (유닛 벡터)
   }

   void OnGUI()
   {
      Camera cam = Camera.main;

      // Cull the object if it is back side of camera
      if (UTGlobalUtility.IsBehindOfMainCamera(cam, transform.position)) return;

      // Draw labels
      Vector3 zeroScrPos = cam.WorldToScreenPoint(transform.position);

      GUI.Label(new Rect(zeroScrPos.x + 30, Screen.height - zeroScrPos.y - 30, 300, 20), gameObject.name);

      GUI.Label(new Rect(zeroScrPos.x + 30, Screen.height - zeroScrPos.y - 60, 300, 20), 
         "World Vector: " + m_Vec.ToString());

      GUI.Label(new Rect(zeroScrPos.x + 30, Screen.height - zeroScrPos.y - 90, 300, 20), 
         "Local Vector: " + transform.InverseTransformDirection(m_Vec).ToString() );

   }

}


