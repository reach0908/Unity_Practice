using UnityEngine;
using System.Collections;

public class CameraTest : MonoBehaviour
{

	void OnPreCull ()
	{
		GetComponent<Camera>().ResetWorldToCameraMatrix ();
		GetComponent<Camera>().ResetProjectionMatrix ();
		
		Debug.Log(GetComponent<Camera>().projectionMatrix.ToString());
		
		GetComponent<Camera>().projectionMatrix = GetComponent<Camera>().projectionMatrix * Matrix4x4.Scale (new Vector3 (1, -1, 1));
		
		Debug.Log(GetComponent<Camera>().projectionMatrix.ToString());
		
	}
	
	void OnPreRender ()
	{
		//GL.SetRevertBackfacing (true);
	}
	
	void OnPostRender ()
	{
		//GL.SetRevertBackfacing (false);
	}
}
