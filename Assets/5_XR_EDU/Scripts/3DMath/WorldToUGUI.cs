using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToUGUI : MonoBehaviour
{
	[SerializeField] private RectTransform m_RootRectTransform;
	[SerializeField] private RectTransform m_RectTr;
	
	[SerializeField] public Vector3 m_TargetPos { get; set; } // world pos
	public Vector2 m_UITargetPos { get; private set; }

	private bool m_BackSide = false;

	/// <summary>
	/// Move the UI element to the world position
	/// </summary>
	/// <param name="a_WorldPosition"></param>
	public void MoveToClickPoint(Vector3 a_WorldPosition)
	{
		if (Camera.main == null) return;

		//then you calculate the position of the UI element
		//0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

		Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(a_WorldPosition);

		Vector2 rectPos = new Vector2(
		((ViewportPosition.x * m_RootRectTransform.sizeDelta.x) - (m_RootRectTransform.sizeDelta.x * 0.5f)),
		((ViewportPosition.y * m_RootRectTransform.sizeDelta.y) - (m_RootRectTransform.sizeDelta.y * 0.5f)));

		Vector3 camFwd = Camera.main.transform.forward;
		Vector3 camToTarget = a_WorldPosition - Camera.main.transform.position;
		float dot = Vector3.Dot(camFwd, camToTarget);

		if (dot < 0)
		{
			m_BackSide = true;
			m_RectTr.gameObject.SetActive(false);
		}
		else
		{
			m_BackSide = false;
			m_RectTr.gameObject.SetActive(true);
		}

		//now you can set the position of the ui element
		m_UITargetPos = rectPos;

		m_RectTr.localPosition = m_UITargetPos;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

	public GameObject m_FollowTarget;

    // Update is called once per frame
    void Update()
    {
		MoveToClickPoint(m_FollowTarget.transform.position);    
    }
}
