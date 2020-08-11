using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
   public Transform m_TargetTr; //대상오브젝트의 트랜스폼 가져오기
   public float m_RightOffset = 0.5f;
   public float m_UpOffset = 0.3f;

    // Update is called once per frame
    void Update()
    {
      transform.position = m_TargetTr.position + (Vector3.right * m_RightOffset) + (Vector3.up * m_UpOffset);
      //transform.position = m_TargetTr.position + (m_TargetTr.right * m_RightOffset) + (m_TargetTr.up * m_UpOffset) ;
      //게임오브젝트의 월드위치 = 타겟의 포지션 
   }

   private void OnDrawGizmos()
   {
      // X axis
      Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (Vector3.right * m_RightOffset), Color.red);
      // Y axis
      Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (Vector3.up * m_UpOffset), Color.green);

      Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (Vector3.right * m_RightOffset) + (Vector3.up * m_UpOffset), Color.white);

      //// X axis
      //Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (m_TargetTr.right * m_RightOffset), Color.red);
      //// Y axis
      //Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (m_TargetTr.up * m_UpOffset), Color.green);

      //Debug.DrawLine(m_TargetTr.position, m_TargetTr.position + (m_TargetTr.right * m_RightOffset) + (m_TargetTr.up * m_UpOffset), Color.white);
   }
}








