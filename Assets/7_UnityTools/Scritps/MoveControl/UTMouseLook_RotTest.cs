/// <summary>
/// Simplified MouseLook
/// 
/// by Yunkyu Choi
/// Last Update: 2011/10/10
/// </summary>
using UnityEngine;
using System.Collections;


public class UTMouseLook_RotTest : MonoBehaviour {
   
   // Up Down Angle
   float m_UpDown = 0f;
   float m_LeftRight = 0f;
   float m_Roll = 0f;
   
   
   void Update ()
   {
#if true // Accmulate Angle
      // Accmulated Angle
      // Rotation about Y Axis (by Mouse X position)
      m_LeftRight += Input.GetAxis("Mouse X") * 10f;
      // Rotation about X Axis (by Mouse Y position)
      m_UpDown += Input.GetAxis("Mouse Y") * 10f;
      // Clamp Up and Down Angle (Prevent rotation mingling)
      m_UpDown = Mathf.Clamp (m_UpDown, -180f, 180f);
      m_LeftRight = Mathf.Clamp(m_LeftRight, -180f, 180f);
#else 
      // Rotation about Y Axis (by Mouse Y position)
      m_LeftRight = Input.GetAxis("Mouse Y") * 10f;
      // Rotation about X Axis (by Mouse X position)
      m_UpDown = Input.GetAxis("Mouse X") * 10f;

      m_Roll = (Input.GetKey(KeyCode.C) ? 1f : 0f) * 1f ;
      
#endif



#if true // Euler Rotations
      // Gimbol locks ------------------------------------------
      
      transform.localEulerAngles = new Vector3(-90, -m_UpDown, m_LeftRight);
      // or
      //transform.rotation = Quaternion.Euler(-90, -m_UpDown, m_LeftRight);
      // or
      // Don't accmulate m_UpDown and m_LeftRight to use below Line
      //transform.Rotate(-90, -m_UpDown, m_LeftRight);

#elif false // Quaternion way1
      // Quaternion -------------------------------------------
      transform.Rotate(Vector3.right, m_Roll, Space.Self);
      transform.Rotate(Vector3.up, -m_UpDown, Space.Self);
      transform.Rotate(Vector3.forward, m_LeftRight, Space.Self);

#else // Quaternion way2
      // Another Quaternion Ex -----------------------------------
      
      // Create quaternions
      Quaternion rotX = Quaternion.AngleAxis(-90, Vector3.right);
      Quaternion rotY = Quaternion.AngleAxis(-m_UpDown, Vector3.up);
      Quaternion rotZ = Quaternion.AngleAxis(m_LeftRight, Vector3.forward);
      
      // set X as -90'
      //transform.localRotation =  rotX;
      // apply other angles
      transform.localRotation = transform.localRotation  * rotY * rotZ;
      // ----------------------------------------------------
#endif

      print("u : " + m_UpDown + " l: " + m_LeftRight);
   }
   
}


