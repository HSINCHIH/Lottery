using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camera_04 : MonoBehaviour {
	int m_CurStep = 0;
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
		this.gameObject.SetActive (true);
		m_CurStep = 0;
	}
}
