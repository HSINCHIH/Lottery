using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoUp : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GetCirclePath ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (Collider collider in Physics.OverlapSphere(new Vector3(0,-2,-50),10)) {
			if (!collider.gameObject.name.Contains ("Ball"))
				continue;
			Rigidbody rigidbody = collider.attachedRigidbody;
			rigidbody.AddForce (0,4000, 0);
			//Debug.Log ("after force");
		}
	}

	//void OnTriggerEnter(Collider other)
	//{
	//	if (other.gameObject.name.Contains ("Ball")) {
	//		Debug.Log (other.gameObject.name);
	//		//GameObject obj = other.gameObject;
	//		//Rigidbody rigidbody = other.attachedRigidbody;
	//		//rigidbody.AddForce (300, 0, 0);
	//		GameObject obj = GameObject.Find(other.gameObject.name);
	//		Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
	//		rigidbody.AddForce (0, 2000, 0);
	//		Debug.Log ("after force");
	//	}
	//}
	void OnCollisionEnter(Collision collision) 
	{
		//if (!m_StartGoUp)
		//	return;
		Debug.Log (collision.gameObject.name);
		////Rigidbody rigidbody = other.attachedRigidbody;
		////rigidbody.AddForce (300, 0, 0);
		//Rigidbody rigidbody = collision.collider.attachedRigidbody;
		//rigidbody.AddForce (0, 2000, 0);
		//Debug.Log ("after force");
	}

	Vector3[] GetCirclePath()
	{
		List<Vector3> pathList = new List<Vector3>();
		float theta = (float)(-Mathf.PI / 2);
		//theta += (Mathf.PI) / 17;
		for (int i = 0; i < 16; i++) 
		{
			float x = 5 * Mathf.Sin (theta);
			float z = 5 * Mathf.Cos (theta);		
			theta += (2 * Mathf.PI) / 16;
			pathList.Add (new Vector3 (x, 0, z));
			GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Cube);
			obj.name = string.Format ("Cover_{0:00}", i);
			obj.transform.position = new Vector3 (x, 0, z);
			obj.transform.localScale = new Vector3 (5, 1, 5);
			obj.transform.LookAt (new Vector3 (0, 0, 0));
		}
		return pathList.ToArray ();
	}
}
