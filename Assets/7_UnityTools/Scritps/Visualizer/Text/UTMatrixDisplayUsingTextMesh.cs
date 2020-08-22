using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityTools.Math;


[RequireComponent(typeof(TextMesh))]
public class UTMatrixDisplayUsingTextMesh : MonoBehaviour
{

   public UTMatrix m_DisplayMatrix = UTMatrix.LocalToWorld;

    public float m_ScaleFactor = 0.5f;
    private string m_NameTag;
    //public float m_PrintDelay = 0.2f;
    private float m_PreTime = 0;
    private TextMesh m_3DText;


    void Init()
    {
        m_3DText = transform.GetComponent<TextMesh>();
        m_NameTag = transform.parent.name;
        name = "DisplayParentMatrix_" + m_NameTag;
    }

    void DrawMatrixToTextMesh()
    {
        m_3DText = transform.GetComponent<TextMesh>();
        
        if (m_3DText == null){ 
            return;
        }
      
      float fixedSizeFactor = HandleUtility.GetHandleSize(transform.position);
      m_3DText.characterSize = m_ScaleFactor * fixedSizeFactor;
      
        string matrixStr;
        
        switch (m_DisplayMatrix)
        {
            case UTMatrix.CamToWorld:
                matrixStr = "CamToWorld of \"" + m_NameTag + "\"\n";
                matrixStr += UTGlobalMathUtility.MatrixToString(
                    transform.parent.GetComponent<Camera>().cameraToWorldMatrix
                    );
                break;

            case UTMatrix.WorldToCam:
                matrixStr = "WorldToCam of \"" + m_NameTag + "\"\n";
                matrixStr += UTGlobalMathUtility.MatrixToString(
                    transform.parent.GetComponent<Camera>().worldToCameraMatrix
                    );
                break;

            case UTMatrix.Projection:
                matrixStr = "Projection of \"" + m_NameTag + "\"\n";
                matrixStr += UTGlobalMathUtility.MatrixToString(
                    transform.parent.GetComponent<Camera>().projectionMatrix
                    );
                break;

            case UTMatrix.LocalToWorld:
                matrixStr = "LocalToWorld Matrix of \"" + m_NameTag + "\"\n";
                matrixStr += UTGlobalMathUtility.MatrixToString(transform.parent.localToWorldMatrix);
                break;
            
            case UTMatrix.WorldToLocal:
                matrixStr = "WorldToLocal Matrix of \"" + m_NameTag + "\"\n";
                matrixStr += UTGlobalMathUtility.MatrixToString(transform.parent.worldToLocalMatrix);
                break;

            default:
                matrixStr = "";
                break;
        }

        m_3DText.text = matrixStr;
        //Debug.Log(transform.localToWorldMatrix.ToString());
    }

//--Unity Functions -----------------------------------------------------------------

    // Use this for initialization
    void Start()
    {
        Init();
    }

    void Reset()
    {
        Init();
    }

    void OnEnable()
    {
        Init();
    }


    void OnDrawGizmos()
    {
        DrawMatrixToTextMesh();
    }

}
