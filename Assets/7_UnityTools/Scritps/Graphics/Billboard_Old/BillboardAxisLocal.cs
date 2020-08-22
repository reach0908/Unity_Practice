using UnityEngine;
using System.Collections;

public class BillboardAxisLocal: MonoBehaviour
{
	public enum RotAxis { X, Y, Z };
	
	public RotAxis m_RotAxis = RotAxis.X;
	
	private Vector3 m_axis1;
	private Vector3 m_axis2;
	
	private int m_axisIdx1;
	private int m_axisIdx2;
	
	private Vector3[] m_axises = {Vector3.right, Vector3.up, Vector3.forward};
	
	void Start()
	{
		switch (m_RotAxis) {
			case RotAxis.X:
				m_axis1 = Vector3.up;
				m_axis2 = Vector3.forward;
				
				m_axisIdx1 = 1;	// Y
				m_axisIdx2 = 2;	// Z
			break;
			
			case RotAxis.Y:
				m_axis1 = Vector3.forward;
				m_axis2 = Vector3.right;
			
				m_axisIdx1 = 2;	// Z
				m_axisIdx2 = 0;	// X
			break;
			
			case RotAxis.Z:
				m_axis1 = Vector3.right;
				m_axis2 = Vector3.up;
			
				m_axisIdx1 = 0;	// X
				m_axisIdx2 = 1;	// Y
			break;
		}
	}
	
	
    // Update is called once per frame
    void Update()
    {
		Vector3 objToCamVec = Camera.main.transform.position - transform.position;
		objToCamVec = transform.InverseTransformDirection(objToCamVec);
		objToCamVec.Normalize();
		
#if UNITY_EDITOR 		
		Debug.DrawLine(transform.position, transform.position + objToCamVec, Color.red);
		Debug.DrawLine(transform.position, transform.position + m_axis1, Color.cyan);
		Debug.DrawLine(transform.position, transform.position + m_axis2, Color.gray);
#endif // UNITY_EDITOR
		
		Vector2 objToCamProj = new Vector2(objToCamVec[m_axisIdx1], objToCamVec[m_axisIdx2]);
		
		float angleToRot = Vector2.Angle(Vector2.up, objToCamProj);
		
		
#if UNITY_EDITOR 	
		Debug.DrawLine(transform.position, transform.position + (Vector3)objToCamProj, Color.green);
		print("Angle : " + angleToRot);
#endif // UNITY_EDITOR
		
		
		if(objToCamProj[m_axisIdx1] > 0){
			angleToRot *= -1;
		}
		
		/*
		Quaternion camRotation = Quaternion.AngleAxis(
		         angleToRot, Vector3.forward);
		
        transform.localRotation *= camRotation;
        */
		
		//transform.Rotate(new Vector3(0,0,angleToRot));
		transform.RotateAround(m_axises[(int)m_RotAxis], angleToRot);
    }
}

