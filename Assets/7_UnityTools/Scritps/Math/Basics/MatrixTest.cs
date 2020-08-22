using UnityEngine;
using System.Collections;
using UnityTools.Math;


public class MatrixTest: MonoBehaviour {
	
	public float m_PrintDelay = 0.2f;
	public float m_PreTime = 0;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float elapsedTime = Time.time - m_PreTime;
		
		if (elapsedTime	> m_PrintDelay ) {
			
			string matrixStr = UTGlobalMathUtility.MatrixToString (transform.localToWorldMatrix);
			
			transform.GetComponentInChildren<TextMesh>().text = matrixStr;
			Debug.Log(transform.localToWorldMatrix.ToString());
			
			m_PreTime = Time.time;
		}
	}
}
