using UnityEngine;
using System.Collections;

public class UETreeCreator2 : MonoBehaviour {
   
   // false로 설정시 랜덤한 트리를 생성한다.
   public bool m_DrawFullTree = true;
   // 한 노드를 생성하고 몇 초를 쉴지 정한다.
   public float m_CreationDelay = 1f;
   // 생성할 노드 번호를 저장한다.
   public int m_NodeCount = 0;

   // Use this for initialization
   void Start () {     
      // 루트 게임오브젝트를 만든다.
      GameObject rootGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
      rootGO.name = "N:" + m_NodeCount;
      UTDisplayTreeNodeInfo info = rootGO.AddComponent<UTDisplayTreeNodeInfo>();

      // 자식 게임오브젝트들을 만든다. (2개의 자식 게임오브젝트를 레벨1 부터 만듬)
      StartCoroutine ( CreateChildren(rootGO.transform, 2, 1) );
   }

   /// <summary>
   /// 자식들을 재귀적으로 추가하는 함수
   /// </summary>
   /// <param name="a_Parent"> 부모 Transform </param>
   /// <param name="a_NumChildren"> 생성 할 자식 게임오브젝트 수 </param>
   /// <param name="a_Level"> 현재 트리 레벨(깊이) </param>
   IEnumerator CreateChildren(Transform a_Parent, int a_NumChildren, int a_Level)
   {
      // 트리 깊이가 3 이상이면 더 이상 자식을 생성하지 않는다.
      if (a_Level > 3) a_NumChildren = 0;
      
      for (int i = 0; i < a_NumChildren; i++)
      {
         // 한 번 생성 할 때 마다 약간씩 쉰다.
         yield return new WaitForSeconds(m_CreationDelay);
         
         // 자식 게임오브젝트를 만든다.
         GameObject childGO = GameObject.CreatePrimitive(PrimitiveType.Cube);

         childGO.name = "N:" + (++m_NodeCount);
         UTDisplayTreeNodeInfo info = childGO.AddComponent<UTDisplayTreeNodeInfo>();

         // 부모를 설정 해준다.
         childGO.transform.parent = a_Parent;

         // 자신의 위치를 설정해 준다.
         float levelAdj = 200f / Mathf.Pow(3f, (float)a_Level) ;
         float posX = a_Parent.position.x + 
            levelAdj / (float)a_NumChildren * (float)i - levelAdj / 4f;
         float posY = a_Parent.position.y - 4f;
         childGO.transform.position = new Vector3(posX, posY, 0f);
         ;

         // 다음 하위 레벨 자식 수를 3개로 한다.
         int NextLevelChild = 3;
         // m_DrawFullTree가 false일 경우 랜덤하게 자식 수를 결정한다.
         if (!m_DrawFullTree)
         {
            NextLevelChild = Random.Range(0, 4);
         }
         
         // 호출 정보를 GUI 라벨로 보여준다.
         info.m_InfoLabel = "Recursive Call i:" + i;
         // 재귀적으로 호출하면서 트리를 구성한다.
         yield return StartCoroutine (
            CreateChildren(childGO.transform, NextLevelChild, a_Level + 1));
         // Recursive Call 라벨을 지우기 전에 딜레이를 둔다.
         yield return new WaitForSeconds(m_CreationDelay);
         // Recursive Call 라벨을 지운다.
         info.m_InfoLabel = "i:" + i;
      }

      yield return null;
   }
}