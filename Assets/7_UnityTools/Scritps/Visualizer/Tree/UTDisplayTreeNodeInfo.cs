using UnityEngine;
using System.Collections;

public class UTDisplayTreeNodeInfo : MonoBehaviour
{
   public string m_NameLabel = "";
   public string m_InfoLabel = "";

   void Start()
   {
      m_NameLabel = name;
   }

   void OnGUI()
   {
      Camera cam = Camera.main;

      // 부모 게임오브젝트의 월드 좌표계를 얻어 온다
      Vector3 worldPos = transform.position;

      // 게임 오브젝트가 카메라 뒤쪽에 있을 경우 GUI Label을 그리지 않는다.
      float distFromCamPlane =
         cam.transform.InverseTransformPoint(transform.position).z;

      if (distFromCamPlane < 0)
         return;

      // GUI.Label을 그리기 위해 월드 좌표계를 스크린 좌표계로 바꾼다.
      Vector3 scrPos = cam.WorldToScreenPoint(worldPos);

      // 라벨을 표시 할 화면의 스크린 Y 좌표 위치를 구한다.
      float scrYPos = Screen.height - scrPos.y - 20f;

      // 스크린 좌표계에 이름을 표시해 준다.
      GUI.Label(new Rect(scrPos.x, scrYPos,
         m_NameLabel.Length * 20, 20), m_NameLabel);
      
      // 다음 라벨의 Y 위치를 아래로 한줄 정도 이동한다.
      scrYPos += 20f;

      // 스크린 좌표계에 정보를 표시해 준다.
      GUI.Label(new Rect(scrPos.x, scrYPos,
         m_InfoLabel.Length * 20, 20), m_InfoLabel);
   }

   void OnDrawGizmos()
   {
      if (transform.parent != null)
         Debug.DrawLine(
            transform.position, transform.parent.position, Color.yellow);
   }

}
