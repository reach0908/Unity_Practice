using UnityEngine;
using System.Collections;

public class SpringDamper : MonoBehaviour {

   public Transform m_Target;

   public float m_K = 1f;
   public float m_SpringLength = 1f;
   public float m_Damper = 0.5f;

   public Vector3 m_F = Vector3.zero;

   // Update is called once per frame
   void Update () {

      // Vector between target and position
      Vector3 vec  = (m_Target.position - transform.position).normalized;

      // Distance
      float x = m_SpringLength - Vector3.Distance(transform.position, m_Target.position);
      m_F += -m_K * x * Time.deltaTime * vec;
      m_F = m_F * m_Damper;

      print(m_F);
      transform.Translate( m_F );

   }
}
