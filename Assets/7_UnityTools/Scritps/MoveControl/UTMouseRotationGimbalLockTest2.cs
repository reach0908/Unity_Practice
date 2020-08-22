/// <summary>
/// Gimbol Lock Test
/// 
/// by Yunkyu Choi
/// Last Update: 2011/10/27
/// </summary>
using UnityEngine;
using System.Collections;


public class UTMouseRotationGimbalLockTest2 : MonoBehaviour
{
   public enum RotationType { 
      EULER, 
      QUATERNION,
   };

   public RotationType m_RotationType = RotationType.EULER;

   float m_RotX = 0f;
   float m_RotY = 0f;
   float m_RotZ = 0f;


   void Start()
   {
      if (m_RotationType == RotationType.QUATERNION)
      {
         transform.localRotation = Quaternion.AngleAxis(-90f, Vector3.right);
      }
      
   }
   void Update()
   {
      // Rotation about Y Axis (by Mouse Y position)
      m_RotY = Input.GetAxis("Mouse Y") * 10f;

      // Rotation about X Axis (by Mouse X position)
      m_RotX = Input.GetAxis("Mouse X") * 10f;

      m_RotZ = (Input.GetKey(KeyCode.C) ? 1f : 0f) * 1f;

      switch (m_RotationType)
      {
         case RotationType.EULER:
            // Gimbol locks ------------------------------------------
            transform.eulerAngles = new Vector3(90f, -m_RotX, m_RotY);
           
            break;


         case RotationType.QUATERNION:
            // Quaternion -------------------------------------------
            
            // Create quaternions
            //Quaternion rotX = Quaternion.AngleAxis(180f, Vector3.right);
            //Quaternion rotX = Quaternion.AngleAxis(m_RotZ, Vector3.right);
            Quaternion rotY = Quaternion.AngleAxis(-m_RotX, Vector3.up);
            Quaternion rotZ = Quaternion.AngleAxis(m_RotY, Vector3.forward);

            // apply other angles at once (Gimbal Lock)
            //transform.localRotation = rotY * rotX * rotZ;

            // multiply angles one by one (No Gimbal Lock)
            //transform.localRotation *= rotZ;
            //transform.localRotation *= rotX;
            //transform.localRotation *= rotY;

            // Gimbal Lock
            //m_RotX = 180f;
            //transform.Rotate(m_RotX, m_RotY, m_RotZ, Space.Self);

            // No Lock
            transform.Rotate(Vector3.forward, m_RotY);
            transform.Rotate(Vector3.right, 180f);
            transform.Rotate(Vector3.up, m_RotX);

            break;


         default:
            break;
      }

      print("X : " + m_RotX + " Y: " + m_RotY + " Z:" + m_RotZ);
   }

}


