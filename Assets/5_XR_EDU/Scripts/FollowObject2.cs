using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject2 : MonoBehaviour
{
   public Transform m_TargetTr;
   public float m_RightOffset = 0.5f;
   public float m_UpOffset = 0.3f;

   private Vector3 m_Offset;

   void Follow()
   {
      transform.position = m_TargetTr.position + m_Offset;
   }

    // Update is called once per frame
    void Update()
    {
      Follow();
   }

   private void OnDrawGizmos()
   {
      Vector3 rightOffset = (Vector3.right * m_RightOffset);
      Vector3 upOffset = (Vector3.up * m_UpOffset);
      m_Offset = rightOffset + upOffset;

      // X axis
      Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + rightOffset, Color.red);
      // Y axis
      Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + upOffset, Color.green);

      Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + m_Offset, Color.white);

      Follow();

      //// X axis
      //Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (m_TargetTr.right * m_RightOffset), Color.red);
      //// Y axis
      //Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (m_TargetTr.up * m_UpOffset), Color.green);

      //Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (m_TargetTr.right * m_RightOffset) + (m_TargetTr.up * m_UpOffset), Color.white);
   }
}








