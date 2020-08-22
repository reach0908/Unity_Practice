using UnityEngine;
using System.Collections;

public class MeshAndMaterialTest1 : MonoBehaviour {

   // Use this for initialization
   void Start () {
      GetComponent<Renderer>().sharedMaterial.color = Color.cyan;
   }
   
   // Update is called once per frame
   void Update () {
   
   }
}
