using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer01 : MonoBehaviour
{
   public float m_MySpeed = 0.01f;
   public GameObject m_MyBullet;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("My player started!!!");
    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log("My player updated!!!   :  " + Time.realtimeSinceStartup);
         
         if( Input.GetKey(KeyCode.LeftArrow) )
         {
            MoveLeft();
         }

         if (Input.GetKey(KeyCode.RightArrow))
         {
            MoveRight();
         }
         
         if (Input.GetKeyUp(KeyCode.Space))
         {
            Instantiate(m_MyBullet, transform.position + new Vector3(0, 0, 1.2f) , Quaternion.identity );
         }
   }

   public void MoveLeft()
   {
      transform.Translate(-m_MySpeed, 0, 0);
   }

   public void MoveRight()
   {
      transform.Translate(m_MySpeed, 0, 0);
   }












}










