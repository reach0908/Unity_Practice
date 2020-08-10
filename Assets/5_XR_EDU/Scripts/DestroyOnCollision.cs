using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      void OnCollisionEnter(Collision collision)
      {
         // 게임오브젝트를 삭제함.
         Destroy(gameObject);

         //foreach (ContactPoint contact in collision.contacts)
         //{
         //   Debug.DrawRay(contact.point, contact.normal, Color.white);
         //}

         //if (collision.relativeVelocity.magnitude > 2)
         //   audioSource.Play();
      }
}
