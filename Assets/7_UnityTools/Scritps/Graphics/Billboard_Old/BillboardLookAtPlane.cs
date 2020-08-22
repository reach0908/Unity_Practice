using UnityEngine;
using System.Collections;

public class BillboardLookAtPlane : MonoBehaviour {

    // 실제 빌보드 함수.
    void LookAtPlane(Vector3 a_Pos)
    {
        // 현재 물체의 Z 축이 a_Pos 위치를 향하게 한다.
        transform.LookAt(a_Pos);
        // 유니티의 기본 Plane은 Y축이 평면이 향하는 방향이므로 X축에 대하여 90도 회전해 준다.
        transform.Rotate(new Vector3(90f, 0));
    }

   // 게임 뷰용 빌보드 갱신.
   void Update () {
        // 메인 카메라를 향하도록 한다.
        LookAtPlane(Camera.main.transform.position);
   }

    // 씬 뷰용 빌보드 갱신.
    void OnDrawGizmos()
    {
        // 현재 씬 뷰를 그리는 카메라를 향하게 한다.
        LookAtPlane(Camera.current.transform.position);
    }
}
