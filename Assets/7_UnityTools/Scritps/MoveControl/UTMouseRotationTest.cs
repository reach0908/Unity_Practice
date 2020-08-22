/// <summary>
/// Gimbol Lock Test
/// 
/// by Yunkyu Choi
/// Last Update: 2011/10/27
/// </summary>
using UnityEngine;
using System.Collections;


public class UTMouseRotationTest : MonoBehaviour
{
   public enum RotationType
   {
      EULER,
      EULER_LOCAL,
      QUATERNION,
      QUATERNION_LOCAL,
      QUATERNION_ABS,
      QUATERNION_LOCAL_ABS,
      ROTATE1,
      ROTATE2,
      ROTATE3
   };
   public RotationType m_RotationType = RotationType.EULER;

   float m_RotXAcc = 0f;
   float m_RotYAcc = 0f;
   float m_RotZAcc = 0f;

   float m_RotX = 0f;
   float m_RotY = 0f;
   float m_RotZ = 0f;


   void Update()
   {
      // 비누적 회전 각도
      // X축에 대한 회전 (C키, 90도 씩 )
      m_RotX = (Input.GetKey(KeyCode.C) ? 90f : 0f);
      // Y축에 대한 회전 (마우스 X)
      m_RotY = Input.GetAxis("Mouse X");
      // Z축에 대한 회전 (마우스 Y)
      m_RotZ = Input.GetAxis("Mouse Y");


      // 누적된 회전 각도
      // X축에 대한 회전 (C키, 90도 씩 )
      m_RotXAcc += (Input.GetKey(KeyCode.C) ? 90f : 0f);
      // Y축에 대한 회전 (마우스 X)
      m_RotYAcc += Input.GetAxis("Mouse X");
      // Z축에 대한 회전 (마우스 Y)
      m_RotZAcc += Input.GetAxis("Mouse Y");


      switch (m_RotationType)
      {
         case RotationType.EULER:
            transform.eulerAngles = new Vector3(m_RotXAcc, m_RotYAcc, m_RotZAcc);
            break;

         case RotationType.EULER_LOCAL:
            transform.localEulerAngles= new Vector3(m_RotXAcc, m_RotYAcc, m_RotZAcc);
            break;

         case RotationType.QUATERNION:
            // 쿼터니언 만들기
            Quaternion rotX = Quaternion.AngleAxis(m_RotX, Vector3.right);
            Quaternion rotY = Quaternion.AngleAxis(m_RotY, Vector3.up);
            Quaternion rotZ = Quaternion.AngleAxis(m_RotZ, Vector3.forward);

            // 쿼터니언 회전 적용
            transform.rotation *= rotZ;
            transform.rotation *= rotX;
            transform.rotation *= rotY;
            break;

         case RotationType.QUATERNION_LOCAL:
            // 쿼터니언 만들기
            Quaternion rotXL = Quaternion.AngleAxis(m_RotX, Vector3.right);
            Quaternion rotYL = Quaternion.AngleAxis(m_RotY, Vector3.up);
            Quaternion rotZL = Quaternion.AngleAxis(m_RotZ, Vector3.forward);

            // 쿼터니언 회전 적용
            transform.localRotation *= rotZL;
            transform.localRotation *= rotXL;
            transform.localRotation *= rotYL;
            break;

         case RotationType.QUATERNION_ABS:
            // 쿼터니언 만들기
            Quaternion rotXA = Quaternion.AngleAxis(m_RotXAcc, Vector3.right);
            Quaternion rotYA = Quaternion.AngleAxis(m_RotYAcc, Vector3.up);
            Quaternion rotZA = Quaternion.AngleAxis(m_RotZAcc, Vector3.forward);

            // 쿼터니언 회전 한번에 적용 (Gimbal Lock)
            transform.rotation = rotYA * rotXA * rotZA;
            
            break;

         case RotationType.QUATERNION_LOCAL_ABS:
            // 쿼터니언 만들기
            Quaternion rotXLA = Quaternion.AngleAxis(m_RotXAcc, Vector3.right);
            Quaternion rotYLA = Quaternion.AngleAxis(m_RotYAcc, Vector3.up);
            Quaternion rotZLA = Quaternion.AngleAxis(m_RotZAcc, Vector3.forward);

            // 쿼터니언 회전 한번에 적용 (Gimbal Lock)
            transform.localRotation = rotYLA * rotXLA * rotZLA;
            break;

         default:
            break;
      }

      print("X : " + m_RotXAcc + " Y: " + m_RotYAcc + " Z:" + m_RotZAcc);

   }

}


