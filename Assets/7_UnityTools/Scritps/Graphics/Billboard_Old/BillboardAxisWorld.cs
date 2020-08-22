using UnityEngine;
using System.Collections;

public class BillboardAxisWorld : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
      Vector3 planeX = transform.TransformDirection(Vector3.right);
      Vector3 planeY = transform.TransformDirection(Vector3.up);
      
      Vector3 objToCamVec = Camera.main.transform.position - transform.position;
      objToCamVec.Normalize();
      
      Debug.DrawLine(transform.position, transform.position + objToCamVec, Color.red);
      
      Debug.DrawLine(transform.position, transform.position + planeX, Color.cyan);
      Debug.DrawLine(transform.position, transform.position + planeY, Color.gray);
      
      
      float projX = Vector3.Dot(planeX, objToCamVec);
      float projY = Vector3.Dot(planeY, objToCamVec);
      

      Vector3 objToCamProj = new Vector3(projX, projY, 0);
      objToCamProj = transform.TransformDirection(objToCamProj);
      
      Debug.DrawLine(transform.position, transform.position + objToCamProj, Color.green);
      
      float angleToRot = Vector3.Angle(
              transform.TransformDirection(Vector3.up), objToCamProj);
      
      print("Angle : " + angleToRot);
      
      
      if(angleToRot > 1){
         angleToRot *= -1;
      }
      /*
      Quaternion camRotation = Quaternion.AngleAxis(
               angleToRot, Vector3.forward);
      
        transform.localRotation *= camRotation;
      */
      
      transform.Rotate(new Vector3(0,0,angleToRot));
    }
}

