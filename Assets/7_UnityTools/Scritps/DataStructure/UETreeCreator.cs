using UnityEngine;
using System.Collections;

public class UETreeCreator : MonoBehaviour {
   
   // 생성 할 노드 번호를 순서대로 저장한다.
   public int m_NodeCount = 0;

   void Start () {
      m_NodeCount = 0;
      /// 루트 게임오브젝트를 만든다.
      
      // Cube 게임오브젝트 생성
      GameObject rootGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
      // 게임오브젝트 이름 설정
      rootGO.name = "L:0" + "_N:" + m_NodeCount;
      
      // 노드 정보를 텍스트로 표시하기 위해 스크립트 추가
      UTDisplayTreeNodeInfo info = rootGO.AddComponent<UTDisplayTreeNodeInfo>();
      
      // 자식들을 추가한다.
      CreateChildren(rootGO.transform, 2, 1);
   }

   /// <summary>
   /// 자식들을 재귀적으로 추가하는 함수
   /// </summary>
   /// <param name="a_Parent"> 부모 Transform </param>
   /// <param name="a_NumChildren"> 생성 할 자식 게임오브젝트 수 </param>
   /// <param name="a_Level"> 현재 트리 레벨(깊이) </param>
   void CreateChildren(Transform a_Parent, int a_NumChildren, int a_Level)
   {
      // 트리 깊이가 3 이상이면 더 이상 자식을 생성하지 않는다.
      if (a_Level > 3) return;
      
      // a_NumChildren 만큼 자식들을 생성
      for (int i = 0; i < a_NumChildren; i++)
      {
         // 자식 게임오브젝트를 만든다.
         GameObject childGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
         // 현재 레벨과 노드 번호(생성 순서)
         childGO.name = "L:" + a_Level + "_N:" + (++m_NodeCount);
         UTDisplayTreeNodeInfo info = 
            childGO.AddComponent<UTDisplayTreeNodeInfo>();

         // 부모를 설정 해준다.(이로써 Hierarchy 에서 부모-자식 관계가 설정된다)
         childGO.transform.parent = a_Parent;

         // 자신의 위치를 설정해 준다. 
         float levelAdj = 20f / (float)a_Level ;
         float posX = a_Parent.position.x + 
            levelAdj / (float)a_NumChildren * (float)i - levelAdj / 4f;
         float posY = a_Parent.position.y - 2f;
         childGO.transform.position = new Vector3(posX, posY, 0f);

         // 다음 하위 레벨 자식 수를 랜덤하게 결정한다.
         int NextLevelChild = Random.Range(0, 3);

         // 재귀적으로 호출하면서 트리를 구성한다.
         CreateChildren(childGO.transform, NextLevelChild, a_Level + 1);
      }
      
      return;
   }
}
