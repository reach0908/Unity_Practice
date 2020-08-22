using UnityEngine;
using System.Collections;

public class UTDisplayNameByGUILabel : MonoBehaviour
{
   public string m_NameLabel;
   public string m_InfoLabel;

   Vector3 m_WorldPos;

   void Init()
   {
      m_NameLabel = name;
      m_InfoLabel = "";
   }

   void Reset()
   {
      Init();
   }

   void Start()
   {
      //Init();
   }

   void OnGUI()
   {
      Camera cam = Camera.main;

      // 부모 게임오브젝트의 월드 좌표계를 얻어 온다
      m_WorldPos = transform.position;

      // 게임 오브젝트가 카메라 뒤쪽에 있을 경우 GUI Label을 그리지 않는다.
      float distFromCamPlane =
         cam.transform.InverseTransformPoint(transform.position).z;

      if (distFromCamPlane < 0)
         return;

      // GUI.Label을 그리기 위해 월드 좌표계를 스크린 좌표계로 바꾼다.
      Vector3 scrPos = cam.WorldToScreenPoint(m_WorldPos);

      // 라벨을 표시 할 화면의 스크린 Y 좌표 위치를 구한다.
      float scrYPos = Screen.height - scrPos.y;

      // 스크린 좌표계에 이름을 표시해 준다.
      GUI.Label(new Rect(scrPos.x, scrYPos,
         m_NameLabel.Length * 10, 20), m_NameLabel);

      scrYPos += 52f;
      m_InfoLabel = "te";
      // 스크린 좌표계에 정보를 표시해 준다.
      GUI.Label(new Rect(scrPos.x, scrYPos,
         m_InfoLabel.Length * 10, 20), m_InfoLabel);
   }
}
