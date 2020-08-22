using UnityEngine;
using System.Collections;

public class BillboardAxisXLocal: MonoBehaviour
{
	
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 planeZ = Vector3.forward;
		Vector3 planeY = Vector3.up;
		
		Vector3 objToCamVec = Camera.main.transform.position - transform.position;
		objToCamVec = transform.InverseTransformDirection(objToCamVec);
		objToCamVec.Normalize();
		
#if UNITY_EDITOR 		
		Debug.DrawLine(transform.position, transform.position + objToCamVec, Color.red);
		Debug.DrawLine(transform.position, transform.position + planeZ, Color.cyan);
		Debug.DrawLine(transform.position, transform.position + planeY, Color.gray);
#endif // UNITY_EDITOR

		Vector2 objToCamProj = new Vector2(objToCamVec.z, objToCamVec.y);

		float angleToRot = Vector2.Angle(Vector2.right, objToCamProj);
		
#if UNITY_EDITOR 	
		Debug.DrawLine(transform.position, transform.position + (Vector3)objToCamProj, Color.green);
		print("Angle : " + angleToRot);
#endif // UNITY_EDITOR
		
		
		
		angleToRot *= (objToCamProj.y > 0 ? -1 : 1);
		
		
		/*
		Quaternion camRotation = Quaternion.AngleAxis(
		         angleToRot, Vector3.forward);
		
        transform.localRotation *= camRotation;
        */
		
		transform.Rotate(angleToRot, 0, 0);
    }
}

