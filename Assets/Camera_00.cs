using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camera_00 : MonoBehaviour {
	string[] m_TargetNames = { "1000", "1100", "1500", "1660", "1664", "1704", "1861", "8000", "8200" };
	List<Vector3> m_TargetPos = new List<Vector3>();

	// Use this for initialization
	void Start () {
		foreach (string name in m_TargetNames) {
			m_TargetPos.Add (GameObject.Find (name).transform.position);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void Active()
	{
	}
}
