using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RotationTest : MonoBehaviour {

   public enum RotationType { WORLD_EULER, LOCAL_EULER, SELF, WORLD };
   
   public RotationType m_RotType = RotationType.WORLD_EULER;

   public Vector3 m_EulerRotation;

   public Vector3 m_RotAxis;

   public float m_RotAngle;


   // Use this for initialization
   void Start () {
   
   }
   
   // Update is called once per frame
   void Update () {
      switch (m_RotType)
      {
         case RotationType.WORLD_EULER:
            transform.Rotate(m_EulerRotation, Space.World);
            
            break;

         case RotationType.LOCAL_EULER:
            transform.Rotate(m_EulerRotation, Space.Self);
            break;

         case RotationType.SELF:
            transform.Rotate(m_RotAxis, m_RotAngle, Space.Self);
            break;

         case RotationType.WORLD:
            transform.Rotate(m_RotAxis, m_RotAngle, Space.World);
            break;

         default:
            break;
      }

   }


}
