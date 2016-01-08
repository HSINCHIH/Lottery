using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camera_03 : MonoBehaviour {
	Vector3 m_OrigPos = Vector3.zero;
	List<Vector3>m_Pathes = new List<Vector3>();
	int m_Frame = 0;
	bool m_Start = false;
	// Use this for initialization
	void Start () {
		m_OrigPos = this.transform.position;
		m_Pathes.AddRange (GetCirclePath ());

	}

	// Update is called once per frame
	void Update () {
		if (m_Start) {
			if (m_Frame >= m_Pathes .Count) {
				m_Frame = 0;
				m_Start = false;
			}
			this.transform.position = m_Pathes [m_Frame];
			if (m_Frame < m_Pathes.Count - 1) {
				this.transform.LookAt (new Vector3 (0, 15, -52.5f));
			}
			m_Frame++;
		}	
	}


	Vector3[] GetCirclePath()
	{
		int step = 200;
		List<Vector3> pathList = new List<Vector3>();
		float theta = (float)(-Mathf.PI);
		//theta += (Mathf.PI * 2) / step;
		for (int i = 0; i < step; i++) 
		{
			float x = 50 * Mathf.Sin (theta);
			float z = 50 * Mathf.Cos (theta) + (-52.5f);
			theta += (Mathf.PI * 2) / step;
			pathList.Add (new Vector3 (x, 40, z));

			//GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Cube);
			//obj.name = string.Format ("point_{0:00}", i);
			//obj.transform.position = new Vector3 (x, 20, z);
		}
		return pathList.ToArray ();
	}

	void Active()
	{
		m_Frame = 0;
		m_Start = true;
	}

}
