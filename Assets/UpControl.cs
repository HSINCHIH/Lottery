using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpControl : MonoBehaviour
{
	bool m_Start = false;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		//foreach (Collider collider in Physics.OverlapSphere(new Vector3(0, -2, -50), 10)) {
		//	if (!collider.gameObject.name.Contains ("Ball"))
		//		continue;
		//	Rigidbody rigidbody = collider.attachedRigidbody;
		//	rigidbody.AddForce (0, 4000, 0);
		//	//Debug.Log ("after force");
		//}
		if (m_Start) {
			if (this.transform.position.y > 25) {
				Destroy (this.gameObject);
				return;
			}
			this.transform.position += new Vector3 (0, 1.0f, 0);
		}
	}

	void SetStartPos (Vector3 pos)
	{
		this.transform.position = pos;
		m_Start = true;
	}
}
