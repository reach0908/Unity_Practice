using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject3 : MonoBehaviour
{
   public Transform m_TargetTr;
   public float m_RightOffset = 0.5f;
   public float m_UpOffset = 0.3f;
   public Camera m_Cam;

   private Vector3 m_Offset;

   void Follow()
   {
      transform.position = m_TargetTr.position + m_Offset;
   }

   private void Start()
   {
      if(m_Cam == null)
         m_Cam = Camera.main;
   }

   // Update is called once per frame
   void Update()
    {
      Follow();
     }


   private void OnDrawGizmos()
   {
      Vector3 rightOffset = (m_Cam.transform.right * m_RightOffset);
      Vector3 upOffset = (m_Cam.transform.up * m_UpOffset);
      m_Offset = rightOffset + upOffset;

      // X axis
      Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + rightOffset, Color.red);
      // Y axis
      Debug.DrawLine(m_TargetTr.position +rightOffset , m_TargetTr.position + rightOffset + upOffset, Color.green);

      Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + m_Offset, Color.white);

      Follow();

   }
}








