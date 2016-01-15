using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateBall : MonoBehaviour
{
	List<Vector3> m_Pathes = new List<Vector3> ();
	int m_BallIndex = 0;
	// Use this for initialization
	void Start ()
	{
		GetCirclePath ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (m_BallIndex < 70) {
			GenerateSingleBall ();
		}
		if (m_BallIndex == 70) {
			this.GetComponent <PickBall> ().enabled = true;
		}
	}

	void GenerateSingleBall ()
	{
		GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		obj.name = string.Format ("Ball_{0:00}", m_BallIndex + 1);
		//obj.tag = "Ball";
		obj.transform.localScale = new Vector3 (3.5f, 3.5f, 3.5f);
		obj.transform.position = m_Pathes [m_BallIndex % m_Pathes.Count];
		string fileName = string.Format (@"Number\{0:00}", m_BallIndex + 1);
		Renderer rend = obj.GetComponent<Renderer> ();
		rend.material.mainTexture = Resources.Load (fileName) as Texture;
		rend.material.SetTextureScale ("_MainTex", new Vector2 (4, 3));
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (0.5f, 0.5f));
		Rigidbody rigidbody = obj.AddComponent<Rigidbody> (); // Add the rigidbody.
		rigidbody.useGravity = true;
		obj.AddComponent<BallControl> ();
		m_BallIndex++;
	}

	void GetCirclePath ()
	{
		int step = 10;
		float theta = (float)(-Mathf.PI);
		//theta += (Mathf.PI * 2) / step;
		for (int i = 0; i < step; i++) {
			float x = 7 * Mathf.Sin (theta);
			float z = 7 * Mathf.Cos (theta) + (-50);
			theta += (Mathf.PI * 2) / step;
			m_Pathes.Add (new Vector3 (x, 10, z));
		}
	}
}
