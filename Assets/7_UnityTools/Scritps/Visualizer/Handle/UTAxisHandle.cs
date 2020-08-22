using UnityEngine;
using System.Collections;


public class UTAxisHandle : MonoBehaviour
{
   public Vector3 m_HandlePosition;
   

   void OnDrawGizmos ()
   {
      transform.LookAt(m_HandlePosition);
      
   }
}

