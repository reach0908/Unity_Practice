using UnityEngine;
using System.Collections;

public class BillboardVertexVersion : MonoBehaviour
{
    public GameObject m_V1;
    public GameObject m_V2;
    public GameObject m_V3;
    public GameObject m_V4;
    
    public Vector3 m_posV1;
    public Vector3 m_posV2;
    public Vector3 m_posV3;
    public Vector3 m_posV4;
    
    public Vector3 m_BillboardCenterPos;

    public MeshFilter m_Mesh;
    public MeshRenderer m_Renderer;
    
    
    // Use this for initialization
    void Awake ()
    {
        m_posV1 = m_V1.transform.localPosition;
        m_posV2 = m_V2.transform.localPosition;
        m_posV3 = m_V3.transform.localPosition;
        m_posV4 = m_V4.transform.localPosition;

        m_Mesh = gameObject.AddComponent<MeshFilter>();
        m_Renderer = gameObject.GetComponent<MeshRenderer>();
        
        Vector3[] verts = new Vector3[4];
        
        verts[0] = m_posV1;
        verts[1] = m_posV2;
        verts[2] = m_posV3;
        verts[3] = m_posV4;

        Vector2[] uvs = new Vector2[4];
        uvs[0] = new Vector2(0f, 1f);
        uvs[1] = new Vector2(1f, 1f);
        uvs[2] = new Vector2(0f, 0f);
        uvs[3] = new Vector2(1f, 0f);

        int[] tris = new int[6];

        tris[0] = 2;
        tris[1] = 0;
        tris[2] = 1;

        tris[3] = 2;
        tris[4] = 1;
        tris[5] = 3;

        Mesh tmpMesh = new Mesh();

        tmpMesh.vertices = verts;
        tmpMesh.uv = uvs;
        tmpMesh.triangles = tris;

        tmpMesh.RecalculateNormals();
        tmpMesh.RecalculateBounds();
        
        m_Mesh.mesh = tmpMesh;
    }

    // Update is called once per frame
    void Update ()
    {
        m_BillboardCenterPos = transform.position;
        Transform camTransform = Camera.main.transform;
        
        
        m_V1.transform.position = 
            m_BillboardCenterPos + camTransform.TransformDirection(m_posV1);
        
        m_V2.transform.position = 
            m_BillboardCenterPos + camTransform.TransformDirection(m_posV2);
        
        m_V3.transform.position = 
            m_BillboardCenterPos + camTransform.TransformDirection(m_posV3);
        
        m_V4.transform.position = 
            m_BillboardCenterPos + camTransform.TransformDirection(m_posV4);

        
        //m_Mesh.mesh.Clear();
        Vector3[] newVs = new Vector3[4];

        newVs[0] = m_V1.transform.localPosition;
        newVs[1] = m_V2.transform.localPosition;
        newVs[2] = m_V3.transform.localPosition;
        newVs[3] = m_V4.transform.localPosition;

        m_Mesh.mesh.vertices = newVs;
        m_Mesh.mesh.RecalculateNormals();
        m_Mesh.mesh.RecalculateBounds();
    }

}
