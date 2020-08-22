using UnityEngine;
using System.Collections;

public class GizmoTest_1 : MonoBehaviour {

   // Use this for initialization
   void Start () {
   
   }
   
   // Update is called once per frame
   void Update () {
   
   }

   void OnDrawGizmos ()
   {
      Vector3 offSetVec = new Vector3(0.01f, 0, 0.01f);

      // 월드 위치
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position + offSetVec, 0.4f);

      // 로컬 위치
      Gizmos.color = Color.blue;
      Gizmos.DrawWireSphere(transform.localPosition, 0.4f);
   }

}
