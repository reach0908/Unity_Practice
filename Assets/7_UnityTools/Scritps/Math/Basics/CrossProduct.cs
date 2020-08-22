using UnityEngine;
using System.Collections;

public class CrossProduct : MonoBehaviour {
    
    public Transform m_VectorATransform;
    public Transform m_VectorBTransform;

    public Color m_ColorA;
    public Color m_ColorB;
    public Color m_CrossResultColor;


   // Use this for initialization
   void Start () {
   
   }
   
   // Update is called once per frame
   void Update () {
   
   }

    void OnGUI()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Label(new Rect(screenPos.x, Screen.height -screenPos.y, 100, 20), "Cross Product");

    }

    void OnDrawGizmos()
    {
        Vector3 vecA = m_VectorATransform.position - transform.position;
        Vector3 vecB = m_VectorBTransform.position - transform.position;

        UTGlobalGizmosUtility.DrawCorssProduct(transform.position, transform.position, vecA, vecB, m_ColorA, m_ColorB, m_CrossResultColor, 0.2f);
       
    }
}
