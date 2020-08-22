using UnityEngine;
using System.Collections;

public class DotProduct : MonoBehaviour {
    public Transform m_VectorA;
    public Transform m_VectorB;

    public Color m_ColorA;
    public Color m_ColorB;
    public Color m_DotResultColor;

   // Use this for initialization
   void Start () {
       
   }
   
   // Update is called once per frame
   void Update () {
        
   }

    void OnDrawGizmos(){
        float dotResultVal = UTGlobalMath.DotProductUsingThreePoints(m_VectorA.position, transform.position, m_VectorB.position);


        Color resultColor = m_DotResultColor * 2f * dotResultVal;
        resultColor.a = 0.8f;

        UTGlobalGizmosUtility.DrawDotProductUsingThreePoints(
            m_VectorA.position, transform.position, m_VectorB.position,
            m_ColorA, m_ColorB, resultColor, 0.2f);
    }
}
