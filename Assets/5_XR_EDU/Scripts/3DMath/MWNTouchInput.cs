using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MWNTouchInput : MonoBehaviour
{
   public LayerMask m_Mask;
   
   public float m_RayDistance = 1500f;   // 1500m
	
   public GameObject m_SomeObject;

   // Update is called once per frame
   void Update()
   {      
      //if (Input.touchCount > 0)  
      if(Input.GetMouseButton(0))
      {
         //Touch touch = Input.GetTouch(0);

         //if (touch.phase == TouchPhase.Began && 
         //   !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
         //{
            
         RaycastHit hit;
         //Ray ray = Camera.main.ScreenPointToRay(touch.position);
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         Physics.Raycast(ray, out hit, m_RayDistance, m_Mask);

            if (hit.transform != null)
            {
               Debug.DrawLine(transform.position, hit.point, Color.yellow);
               Debug.Log("Hit!! : " +hit.point.ToString());

               m_SomeObject.transform.position = hit.point;
               return;
            }
            else
            {
               //Debug.Log("No Hit!!");
            }

         //}
      }
   }// End of Function

}// End of Class
