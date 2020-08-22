using UnityEngine;
using System.Collections;
using UnityTools.Math;


[RequireComponent(typeof(UnityEngine.UI.Text))]
public class UTMatrixDisplayUsingGUIText : MonoBehaviour
{

   public UTMatrix m_DisplayMatrix = UTMatrix.LocalToWorld;

   
   public Vector3 m_WorldPos;
   
   
   private string m_NameTag;
   
   //public float m_PrintDelay = 0.2f;
   private float m_PreTime = 0;
   private UnityEngine.UI.Text m_GUIText;


   void Init ()
   {
      m_GUIText = transform.GetComponent<UnityEngine.UI.Text> ();
      m_NameTag = transform.parent.name;
      name = "DisplayParentMatrix_" + m_NameTag;
   }

   
   void DrawMatrixToText ()
   {
      m_GUIText = transform.GetComponent<UnityEngine.UI.Text> ();
      
      if (m_GUIText == null) {
         return;
      }
      
      
      
      /// Position
      Camera cam;
      
     // 실행 중인 경우는 메인 카메라를 기준으로
      if (Application.isPlaying)
      {
         cam = Camera.main;
      }
      else // 비 실행 중에는 씬뷰 카메라를 기준으로 한다.
      {
         cam = Camera.current;
      }

      // 부모 게임오브젝트의 월드 좌표계를 얻어 온다
      m_WorldPos = transform.parent.position;
      
      // 부모 게임 오브젝트가 카메라 뒤쪽에 있을 경우 GUI Text를 그리지 않는다.
     float distFromCamPlane =
        cam.transform.InverseTransformPoint(transform.position).z;

     if (distFromCamPlane < 0)      return;
      
      
      // 부모 게임오브젝트의 뷰포트 좌표계를 얻어 온다.
      transform.position = cam.WorldToViewportPoint(m_WorldPos);
      
      
      
      string matrixStr;
      
      switch (m_DisplayMatrix) {
      case UTMatrix.CamToWorld:
         matrixStr = "CamToWorld of \"" + m_NameTag + "\"\n";
         matrixStr += UTGlobalMathUtility.MatrixToString (transform.parent.GetComponent<Camera>().cameraToWorldMatrix);
         break;
      
      case UTMatrix.WorldToCam:
         matrixStr = "WorldToCam of \"" + m_NameTag + "\"\n";
         matrixStr += UTGlobalMathUtility.MatrixToString (transform.parent.GetComponent<Camera>().worldToCameraMatrix);
         break;
      
      case UTMatrix.Projection:
         matrixStr = "Projection of \"" + m_NameTag + "\"\n";
         matrixStr += UTGlobalMathUtility.MatrixToString (transform.parent.GetComponent<Camera>().projectionMatrix);
         break;
      
      case UTMatrix.LocalToWorld:
         matrixStr = "LocalToWorld Matrix of \"" + m_NameTag + "\"\n";
         matrixStr += UTGlobalMathUtility.MatrixToString (transform.parent.localToWorldMatrix);
         break;
      
      case UTMatrix.WorldToLocal:
         matrixStr = "WorldToLocal Matrix of \"" + m_NameTag + "\"\n";
         matrixStr += UTGlobalMathUtility.MatrixToString (transform.parent.worldToLocalMatrix);
         break;
      default:
         
         matrixStr = "";
         break;
      }
      
      m_GUIText.text = matrixStr;
      //Debug.Log(transform.localToWorldMatrix.ToString());
   }
 
   
//--Unity Functions -----------------------------------------------------------------------------------//

   // Use this for initialization
   void Start ()
   {
      Init ();
   }
 
   
   void Reset ()
   {
      Init ();
   }
 
   
   void OnEnable ()
   {
      Init ();
   }


   // Update is called once per frame
   void Update ()
   {
      
      //float elapsedTime = Time.time - m_PreTime;
      
      //if (elapsedTime > m_PrintDelay)
      {
         DrawMatrixToText ();
         //m_PreTime = Time.time;
      }

   }


   void OnDrawGizmos ()
   {
      DrawMatrixToText ();
   }
   
}


