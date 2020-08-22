using UnityEngine;
using System.Collections;

public class BillboardRotation : MonoBehaviour
{

    public GameObject m_V1;
    public GameObject m_V2;
    public GameObject m_V3;
    public GameObject m_V4;

    public GameObject m_Plane;


    public Vector3 m_posV1;
    public Vector3 m_posV2;
    public Vector3 m_posV3;
    public Vector3 m_posV4;

    public Quaternion m_PlaneRot;

    // Use this for initialization
    void Start()
    {
        m_posV1 = m_V1.transform.localPosition;
        m_posV2 = m_V2.transform.localPosition;
        m_posV3 = m_V3.transform.localPosition;
        m_posV4 = m_V4.transform.localPosition;

        m_PlaneRot = m_Plane.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion camRotation = Camera.main.transform.rotation;

        m_V1.transform.localPosition = camRotation * m_posV1;
        m_V2.transform.localPosition = camRotation * m_posV2;
        m_V3.transform.localPosition = camRotation * m_posV3;
        m_V4.transform.localPosition = camRotation * m_posV4;

        m_Plane.transform.localRotation = camRotation * m_PlaneRot;
    }
}

