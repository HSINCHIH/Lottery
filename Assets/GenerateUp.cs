using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateUp : MonoBehaviour
{
	List<List<Vector3>> m_Pathes = new List<List<Vector3>> ();
	int m_UnPickBalls = 70;
	// Use this for initialization
	void Start ()
	{
		m_Pathes.Add (GetCirclePath (3, 6));
		m_Pathes.Add (GetCirclePath (4, 6));
		m_Pathes.Add (GetCirclePath (4, 6));
		m_Pathes.Add (GetCirclePath (4, 6));
		m_Pathes.Add (GetCirclePath (10, 6));
		m_Pathes.Add (GetCirclePath (10, 7));
		m_Pathes.Add (GetCirclePath (12, 7));
		m_Pathes.Add (GetCirclePath (12, 7));
		m_Pathes.Add (GetCirclePath (15, 7));
		m_Pathes.Add (GetCirclePath (15, 7));
	}
	
	// Update is called once per frame
	void Update ()
	{		
		foreach (Vector3 pos in m_Pathes[Mathf.Min(9, m_UnPickBalls / 7)]) {
			foreach (Collider collider in Physics.OverlapSphere(pos, 2)) {
				if (!collider.gameObject.name.Contains ("Ball"))
					continue;
				Rigidbody rigidbody = collider.attachedRigidbody;
				int forceX = Random.Range (1, 5) * 50;
				int forceZ = Random.Range (1, 5) * 50;
				rigidbody.AddForce (forceX, 2000, forceZ);
			}
		}
	}

	List<Vector3> GetCirclePath (int step, float radius)
	{
		List<Vector3> temp = new List<Vector3> ();
		float theta = (float)(-Mathf.PI);
		//theta += (Mathf.PI * 2) / step;
		for (int i = 0; i < step; i++) {
			float x = radius * Mathf.Sin (theta);
			float z = radius * Mathf.Cos (theta) + (-50);
			theta += (Mathf.PI * 2) / step;
			temp.Add (new Vector3 (x, 0, z));
			//GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			//obj.transform.localScale = new Vector3 (3, 3, 3);
			//obj.name = string.Format ("point_{0:00}", i);
			//obj.transform.position = new Vector3 (x, 0, z);
		}
		return temp;
	}

	void SetBallCount (int count)
	{
		m_UnPickBalls = count;
		//Debug.Log (string.Format ("SetBallCount : {0}", count));
	}
}
