using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateProduct : MonoBehaviour {
	List<GameObject> m_Balls = new List<GameObject>();
	int m_BallIndex = 0;
	List<GameObject> m_SelectBalls = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
		//GenerateProduct ();
		GenerateTube();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_BallIndex < 70) 
		{
			GenerateBall ();
		}
		GameObject hightBall = null;
		float maxY = -1.0f;
		foreach (GameObject obj in m_Balls)	{
			if (obj.transform.position.y > maxY) {
				maxY = obj.transform.position.y;
				hightBall = obj;
			}
		}
		if (maxY > 24.0) 
		{
			m_Balls.Remove (hightBall);
			//Rigidbody rigidbody = hightBall.GetComponent<Rigidbody> ();
			//Destroy (rigidbody);
			//hightBall.transform.position = new Vector3 (-50 + m_SelectBalls.Count * 5, 0, -70);
			//Quaternion quate = Quaternion.identity;
			//hightBall.transform.rotation = quate;
			hightBall.SendMessage("Select",m_SelectBalls.Count);
			m_SelectBalls.Add (hightBall);
		}
	}

	Vector3[] GetProductPath()
	{
		List<Vector3> pathList = new List<Vector3>();
		float theta = (float)(-Mathf.PI/2);
		theta += (Mathf.PI*2) / 16;
		for (int i = 0; i < 16; i++) 
		{
			float x = 2.5f * Mathf.Sin (theta);
			float z = 2.5f * Mathf.Cos (theta);		
			theta += (Mathf.PI*2) / 16;
			pathList.Add (new Vector3 (x, 0, z));
		}
		return pathList.ToArray ();
	}
	//void GenerateProduct()
	//{
	//	string[] productList = {
	//		"RS30",
	//		"CP60",
	//		"CP55",
	//		"CP50",
	//		"9700",
	//		"9200",
	//		"8600",
	//		"8400",
	//		"8300",
	//		"8200",
	//		"8000",
	//		"1000",
	//		"1100",
	//		"1500",
	//		"1704",
	//		"1861"
	//	};
	//	Vector3[] pathList = 	GetProductPath();
	//	for (int i = 0; i < pathList.Length; i++) 
	//	{
	//		Vector3 pos = pathList[i];
	//		GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Cube);
	//		obj.name = string.Format ("{0}", productList [i]);
	//		obj.transform.localScale = new Vector3 (8, 8, 0.1f);
	//		obj.transform.position = new Vector3 (pos.x, 0, pos.z);
	//		obj.transform.LookAt (new Vector3 (0, 0, -50));
	//		string fileName = string.Format (@"Product\{0}", productList [i]);
	//		Renderer rend = obj.GetComponent<Renderer>();
	//		rend.material.mainTexture = Resources.Load(fileName) as Texture;
	//		rend.material.shader = Shader.Find("Transparent/Diffuse");
	//	}
	//}
	void GenerateBall()
	{
		GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		obj.name = string.Format ("Ball_{0:00}", m_BallIndex + 1);
		obj.transform.localScale = new Vector3 (3.5f, 3.5f, 3.5f);
		//obj.transform.position = new Vector3 (3.5f * (m_BallIndex % 2), 20 + m_BallIndex * 4, -50);
		//obj.transform.position = new Vector3 (3.5f * (m_BallIndex % 2), 5, -50);
		obj.transform.position = new Vector3 (-8, 8, -52);
		string fileName = string.Format (@"Number\{0:00}", m_BallIndex + 1);
		Renderer rend = obj.GetComponent<Renderer> ();
		rend.material.mainTexture = Resources.Load (fileName) as Texture;
		rend.material.SetTextureScale ("_MainTex", new Vector2 (4, 3));
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (0.5f, 0.5f));
		Rigidbody rigidbody = obj.AddComponent<Rigidbody> (); // Add the rigidbody.
		rigidbody.useGravity = true;
		//SphereCollider collider = obj.GetComponent<SphereCollider>();
		//collider.isTrigger = true;
		obj.AddComponent<BallHandler> ();
		m_Balls.Add(obj);
		m_BallIndex++;
	}
	void GenerateTube()
	{
		Vector3[] pathList = GetProductPath();
		for (int i = 0; i < pathList.Length; i++) 
		{
			Vector3 pos = pathList[i];
			GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Cube);
			obj.name = string.Format ("Tube_{0:00}", i);
			obj.transform.localScale = new Vector3 (1f, 1, 0.1f);
			obj.transform.position = new Vector3 (pos.x, 0, pos.z);
			obj.transform.LookAt (new Vector3 (0, 0, 0));
			//string fileName = string.Format (@"Product\{0}", productList [i]);
			//Renderer rend = obj.GetComponent<Renderer>();
			//rend.material.mainTexture = Resources.Load(fileName) as Texture;
			//rend.material.shader = Shader.Find("Transparent/Diffuse");
		}
	}

}
