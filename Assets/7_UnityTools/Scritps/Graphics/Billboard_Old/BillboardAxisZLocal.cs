using UnityEngine;
using System.Collections;

public class BillboardAxisZLocal: MonoBehaviour
{
	
    // Use this for initialization
    void Start()
    {
        
    }
	
    void Update()
    {
		Vector3 planeX = Vector3.right;
		Vector3 planeY = Vector3.up;
		
		Vector3 objToCamVec = Camera.main.transform.position - transform.position;
		objToCamVec = transform.InverseTransformDirection(objToCamVec);
		objToCamVec.Normalize();
		
#if UNITY_EDITOR 		
		Debug.DrawLine(transform.position, transform.position + objToCamVec, Color.red);
		Debug.DrawLine(transform.position, transform.position + planeX, Color.cyan);
		Debug.DrawLine(transform.position, transform.position + planeY, Color.gray);
#endif // UNITY_EDITOR

		Vector2 objToCamProj = new Vector2(objToCamVec.x, objToCamVec.y);

		float angleToRot = Vector2.Angle(Vector2.up, objToCamProj);
		
#if UNITY_EDITOR 	
		Debug.DrawLine(transform.position, transform.position + (Vector3)objToCamProj, Color.green);
		print("Angle : " + angleToRot);
#endif // UNITY_EDITOR
		
		
		if(objToCamProj.x > 0){
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

