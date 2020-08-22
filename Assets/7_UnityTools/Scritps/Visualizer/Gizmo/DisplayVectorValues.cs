using UnityEngine;
using System.Collections;

public class DisplayVectorValues : MonoBehaviour {

    public Transform m_ToTransform;
    public Transform m_FromTransform;

    public Color m_Color;

    public bool m_Normalize = true;

   // Use this for initialization
   void Start () {
   
   }
   
   // Update is called once per frame
   void Update () {
   
   }

    void Reset()
    {
        m_FromTransform = transform;
    }
    void OnDrawGizmos()
    {
        Vector3 vector = m_ToTransform.position - m_FromTransform.position;

        if (m_Normalize)
        {
            vector.Normalize();
        }

        UTGlobalGizmosUtility.DrawVectorAtPoint(m_FromTransform.position, vector, 0.2f, m_Color);
    }
}
