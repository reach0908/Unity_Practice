using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reflect VecP over VecN and save the result on VecR
/// </summary>
public class VectorReflection : MonoBehaviour
{
	
	public bool m_UnityFunctionMode = false;
	
	public Vector3 m_LocalVecP = Vector3.forward; // (0, 0, 1)
	public Vector3 m_VecP;	// World version of m_LocalVecP (Calculated automatically)
	
	public Vector3 m_VecN = Vector3.up;	// World Vector

	public Vector3 m_VecR = Vector3.zero;

	private void OnEnable()
	{
		// Normalized the normal vector
		m_VecN = Vector3.Normalize(m_VecN);
							// m_VecN.normalized;
	}

	private Vector3 ReflectVectorOverVector()
	{
		// Fig. 1
		Vector3 projVecP = m_VecN * Vector3.Dot( -m_VecP, m_VecN );

		Vector3 reflectionVec = m_VecP + (2f * projVecP);

		return reflectionVec;
	}


	private void OnDrawGizmos()
	{
		m_VecP = transform.TransformVector(m_LocalVecP);
		
		if(m_UnityFunctionMode)
				m_VecR = Vector3.Reflect(m_VecP, m_VecN);
			else
				m_VecR = ReflectVectorOverVector();
		
		Vector3 worldPos = transform.position;

		Debug.DrawLine(worldPos, worldPos - m_VecP, Color.red);
		Debug.DrawLine(worldPos, worldPos + m_VecN, Color.green);
		Debug.DrawLine(transform.position, transform.position + m_VecR, new Color(0.5f, 0f, 1f));


	}

	void OnGUI()
	{
		Camera cam = Camera.main;

		// Draw labels
		Vector3 zeroScrPos = cam.WorldToScreenPoint(transform.position);

		GUI.Label(new Rect(zeroScrPos.x, Screen.height - zeroScrPos.y + 30, 300, 20), gameObject.name);
	}
}
