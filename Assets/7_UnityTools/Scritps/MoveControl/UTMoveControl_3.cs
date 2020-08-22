using UnityEngine;
using System.Collections;

/// <summary>
/// 방향키와 마우스 조작으로 캐릭터를 움직이는 스크립트
/// </summary>
public class UTMoveControl_3 : MonoBehaviour
{
   // 이동 속도
   public float m_Speed = 1f;

   // 그려진 Debug.DrawLine이 씬상에 남아 있는 시간(초단위)
   public float m_duration = 2f;

   void Update ()
   {
      // 키보드나 조이스틱의 방향을 얻어 온다.
      Vector3 xVec = new Vector3( Input.GetAxis ("Horizontal"), 0, 0 );
      Vector3 zVec = new Vector3( 0, 0, Input.GetAxis ("Vertical") );

      Vector3 dirVec = xVec + zVec;
      
      // 정규화된 벡터를 구함.
      Vector3 moveVec = dirVec.normalized;

      // 기종 및 각 프레임을 그리는 시간에 상관업이 일정한 속도로
      // 움직이기 위해 프레임간 시간을 곱해준다.
      transform.position += moveVec * Time.deltaTime * m_Speed;

#if UNITY_EDITOR  // 유니티 최종 빌드에서는 포함 되지 않는다.

      // 자신의 월드 좌표계 위치를 Y축으로 0.02 만큼 씩 이동한 위치를 구하여.
      // 선이 겹처져 그려지는 것을 방지하기 위한 새로운 기준점으로 사용한다.
      Vector3 offsetPos = transform.position + new Vector3(0, 0.02f, 0);

      // 빨간색으로 정규화 되지 않은 X축 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos, offsetPos+ xVec, Color.red);

      // 파란색으로 정규화 되지 않은 Z축 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos, offsetPos + zVec, Color.blue);

      // 자홍색으로 정규화 되지 않은 이동 방향 벡터를 그려준다.
      Debug.DrawLine(offsetPos, offsetPos + dirVec, Color.magenta);

      // 흰색으로 정규화 된 벡터를 그려준다.
      Debug.DrawLine(transform.position, transform.position + moveVec, Color.white);

      // 앞쪽 방향으로 노란색 광선을 그려준다.
      Debug.DrawRay(transform.position, transform.forward, Color.yellow);

#endif
   }

   void OnDrawGizmos()
   {
      // 현재 게임오브젝트의 위치에 0.1 반지름의 붉은색 구체를 그려준다.
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, 0.1f);

      // localToWorldMatrix를 x축, y축 각각 0.2 만큼 이동하여 
      // Gizmo matrix를 설정해 준다.
      Matrix4x4 offsetLocalMat = transform.localToWorldMatrix;
      offsetLocalMat.m03 += 0.2f;
      offsetLocalMat.m13 += 0.2f;

      Gizmos.matrix = offsetLocalMat;

      // 우측 방향 길이 3인 광선을 붉은 색으로 그린다.
      Gizmos.color = Color.red;
      Gizmos.DrawRay(Vector3.zero, Vector3.right * 3f);
      
      // 위쪽 방향 길이 2인 광선을 초록색으로 위쪽 방향으로 그린다.
      Gizmos.color = Color.green;
      Gizmos.DrawRay(Vector3.zero, Vector3.up * 2f);

      // 정면방향 길이 1인 광선을 파란색으로 그린다
      Gizmos.color = Color.blue;
      Gizmos.DrawRay(Vector3.zero, Vector3.forward);
   }
}

