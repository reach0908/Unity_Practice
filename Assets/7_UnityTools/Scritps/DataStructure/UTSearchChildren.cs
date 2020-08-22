using UnityEngine;
using System.Collections;


// GUIText 컴포넌트가 없을 경우 추가 시켜준다.
[RequireComponent(typeof(UnityEngine.UI.Text))]
public class UTSearchChildren : MonoBehaviour {
   
   // 한 노드를 방문 하고 몇 초를 쉴지 정한다.
   public float m_SearchDelay = 1f;

   // 자식들을 순회 할 대상 부모 게임 오브젝트 
   public GameObject m_GOforSearch;

   // 방문한 노드들의 숫자를 저장한다.
   public int m_ChildCount = 0;
   
   // 방문 순서를 GUIText로 화면에 표시해 주기 위한 GUIText 컴포넌트
   private UnityEngine.UI.Text m_TextOut;


   // Use this for initialization
   void Start () {
      // 방문순서를 GUIText로 보여주기 위해 GUIText를 얻어온다.
      m_TextOut = GetComponent<UnityEngine.UI.Text>();
      
      // 순회 할 대상 게임오브젝트의 Transform을 재귀호출 함수에 전달한다.
      StartCoroutine ( SearchChildren(m_GOforSearch.transform) );
   }

   /// <summary>
   /// 인자로 받은 Transform의 자식들을 재귀호출로 깊이우선 탐색한다.
   /// </summary>
   /// <param name="a_Parent"> 자식들이 방문 될 부모 Transform </param>
   /// <returns></returns>
   IEnumerator SearchChildren(Transform a_Parent)
   {
      // 방문 순서를 화면 상단에 GUIText로 표시해 준다.
      string childName = "  V:" + (++m_ChildCount) + "-" + a_Parent.name;
      m_TextOut.text += childName;

      //-------------------- 방문 전 -----------------------------------------
      // 한 번 탐색 할 때 마다 약간씩 쉰다.
      yield return new WaitForSeconds(m_SearchDelay);

      // 각 게임오브젝트의 하단에도 방문 순서를 표시해 준다.
      UTDisplayTreeNodeInfo info = 
         a_Parent.GetComponent<UTDisplayTreeNodeInfo>();
      info.m_InfoLabel = "Recursive Call~ V:" + m_ChildCount;

      // 방문 시 게임오브젝트를 1.1 배씩 키워준다. (자식들에게도 적용 됨)
      a_Parent.localScale *= 1.1f;
      //----------------------------------------------------------------------

      // 자신의 모든 자식들에 대해서 재귀호출 해준다.----------------------------
      foreach (Transform child in a_Parent)
      {   
         yield return StartCoroutine(SearchChildren(child));
      }
      //----------------------------------------------------------------------

      //-------------------- 방문 후 -----------------------------------------
      // 한 번 return 하기 전 마다 약간씩 쉰다.
      yield return new WaitForSeconds(m_SearchDelay);

      // return 전에 게임오브젝트 크기를 원상 복귀 해 준다.
      a_Parent.localScale /= 1.1f;
      // 방문 후 게임오브젝트 에서 return 시 "Recursive Call~" 이란 글자를 지워준다.
      info.m_InfoLabel = info.m_InfoLabel.Replace("Recursive Call~ ", "");
      //----------------------------------------------------------------------

      yield return null;
   }
}