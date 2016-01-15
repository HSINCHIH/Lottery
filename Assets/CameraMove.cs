using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMove : MonoBehaviour {
	List<List<Vector3>>m_CameraPathes = new List<List<Vector3>>();
	int m_FrameIndex = 0;
	bool m_StartPath = true;
	int m_SelectIndex = 0;
	// Use this for initialization
	void Start () {
		GetCirclePath();
	}

	// Update is called once per frame
	void Update () {
		if (m_StartPath) {
			GoPath ();
			m_FrameIndex++;
		}
	}

	Vector3[] GetCirclePath()
	{
		int step = 300;
		List<Vector3> pathList = new List<Vector3>();
		float theta = (float)(-Mathf.PI);
		//theta += (Mathf.PI * 2) / step;
		for (int i = 0; i < step; i++) 
		{
			float x = 170 * Mathf.Sin (theta);
			float z = 50 * Mathf.Cos (theta) + -70.0f;	
			theta += (Mathf.PI*2) / step;
			pathList.Add (new Vector3 (x, 0, z));

			//GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Cube);
			//obj.name = string.Format ("point_{0:00}", i);
			//obj.transform.position = new Vector3 (x, 0, z);
		}
		m_CameraPathes.Add (pathList);
		return pathList.ToArray ();
	}

	void GoPath()
	{
		Vector3 curStep = m_CameraPathes [m_SelectIndex] [m_FrameIndex % m_CameraPathes [m_SelectIndex].Count];
		this.transform.position = curStep;
		Vector3 nextStep = m_CameraPathes [m_SelectIndex] [(m_FrameIndex + 1) % m_CameraPathes [m_SelectIndex].Count];
		this.transform.LookAt (nextStep);
	}
}
