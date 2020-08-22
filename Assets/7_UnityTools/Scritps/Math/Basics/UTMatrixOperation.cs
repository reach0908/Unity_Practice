using UnityEngine;
using System.Collections;

public class UTMatrixOperation : MonoBehaviour {
 
   public Transform m_TransformA;
   public Transform m_TransformB;
   public Transform m_OutTransform;
   
   public Matrix4x4 m_Mat44A;
   public Matrix4x4 m_Mat44B;
   public Matrix4x4 m_OutMat44;
   
   public delegate void MatrixOp(Matrix4x4 a_Mat44A, Matrix4x4 a_Mat44B, out Matrix4x4 a_OutMat44);
   public MatrixOp MatOpFunc = null;
   
	// Use this for initialization
	void Start () {
	   
      MatOpFunc = Mul;
      
      MatOpFunc(m_Mat44A, m_Mat44B, out m_OutMat44);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
   
   
   // Matrix Operations
   public void Mul(Matrix4x4 a_Mat44A, Matrix4x4 a_Mat44B, out Matrix4x4 a_OutMat44)
   {
      
      print("Test");
      a_OutMat44 = Matrix4x4.identity;
      return;
   }
                           
   void MatrixOp1(Matrix4x4 a_Mat44A, Matrix4x4 a_Mat44B, out Matrix4x4 a_OutMat44){
      
      a_OutMat44 = Matrix4x4.identity;
      
   }
}
