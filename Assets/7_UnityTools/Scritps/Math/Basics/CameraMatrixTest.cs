using UnityEngine;
using System.Collections;
using UnityTools.Math;
	
public class CameraMatrixTest : MonoBehaviour
{
    public Camera m_CameraForVisualize;
    
    public enum YKCameraMatrix {CamToWorld, WorldToCam, Projection };

    public YKCameraMatrix m_SelectMatirx = YKCameraMatrix.WorldToCam;

    public bool m_FixMessage = false;
    public string m_NameTag;
    private string m_Message;

    public float m_PrintDelay = 0.2f;
    private float m_PreTime = 0;
    

    void Reset()
    {
        m_CameraForVisualize = transform.parent.GetComponent<Camera>();
        m_NameTag = transform.parent.name;
    }

    void DrawMatrixToTextMesh()
    {
        if (m_FixMessage){ return;}

        //Camera.main.ResetWorldToCameraMatrix();

        string matrixStr = "";
        Matrix4x4 matrix4x4 = Matrix4x4.identity;

        switch (m_SelectMatirx)
        {
            case YKCameraMatrix.CamToWorld:
                matrix4x4 = m_CameraForVisualize.cameraToWorldMatrix;
                matrixStr += "CamToWorld of \"";
                break;

            case YKCameraMatrix.WorldToCam:
                matrix4x4 = m_CameraForVisualize.worldToCameraMatrix;
                matrixStr += "WorldToCam of \"";
                break;

            case YKCameraMatrix.Projection:
                matrix4x4 = m_CameraForVisualize.projectionMatrix;
                matrixStr += "Projection of \"";
                break;

            default:
                Debug.Log("Error");
                break;
        }

        matrixStr += m_NameTag + "\"\n";
        matrixStr += UTGlobalMathUtility.MatrixToString( matrix4x4 );

        transform.GetComponent<TextMesh>().text = matrixStr;
        m_Message = matrixStr;

        //Debug.Log(transform.localToWorldMatrix.ToString());
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float elapsedTime = Time.time - m_PreTime;

        if (elapsedTime > m_PrintDelay)
        {

            DrawMatrixToTextMesh();
            m_PreTime = Time.time;
        }
    }

    void OnDrawGizmos()
    {

        DrawMatrixToTextMesh();
    }
}
