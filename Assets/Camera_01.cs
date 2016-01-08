using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camera_01 : MonoBehaviour {
	Vector3 m_OrigPos = Vector3.zero;
	string[] m_TargetNames = { "1000", "1100", "1500", "1660", "1664", "1704", "1861", "8000", "8200" };
	List<Vector3> m_TargetPos = new List<Vector3>();
	List<Vector3> m_TargetVector = new List<Vector3>();
	List<Vector3> m_StartPos = new List<Vector3>();
	List<List<Vector3>>m_Pathes = new List<List<Vector3>>();
	int m_Frame = 0;
	int m_TargetIndex = 0;
	bool m_Start = false;
	// Use this for initialization
	void Start () {
		m_OrigPos = this.transform.position;
		foreach (string name in m_TargetNames) {
			Vector3 target = GameObject.Find (name).transform.position;
			Vector3 frontTarget = GameObject.Find (string.Format ("Front_{0}", name)).transform.position;
			Vector3 targetVector = frontTarget - target;
			m_TargetPos.Add (target);
			m_TargetVector.Add (targetVector);
			m_StartPos.Add (target + 10 * targetVector);
		}
		int step = 60;
		for (int i = 0; i < m_TargetPos.Count; i++) {
			List<Vector3> temp = new List<Vector3> ();
			List<Vector3> tempReverse = new List<Vector3> ();
			List<Vector3> result = new List<Vector3> ();
			for (int j = 0; j < step; j++) {
				temp.Add (Vector3.Lerp (m_StartPos[i], m_TargetPos[i], j / 85.0f));
			}
			int index = temp.Count - 1;
			for (int j = 0; j < 10; j++) {
				temp.Add (temp [index]);
			}
			for (int j =  temp.Count -1; j >=0; j--) {
				tempReverse.Add (temp [j]);
			}
			result.AddRange (temp.ToArray ());
			result.AddRange (tempReverse.ToArray ());
			m_Pathes.Add (result);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (m_Start) {
			if (m_Frame >= m_Pathes [m_TargetIndex].Count) {
				m_Frame = 0;
				m_TargetIndex++;
				if (m_TargetIndex >= m_Pathes.Count) {
					m_Start = false;
				}
			}
			this.transform.position = m_Pathes [m_TargetIndex] [m_Frame];
			if(m_Frame <  m_Pathes [m_TargetIndex].Count-1)
			{
				this.transform.LookAt (m_TargetPos [m_TargetIndex]);
			}
			m_Frame++;
		}	
	}

	void Active()
	{
		m_Frame = 0;
		m_TargetIndex = 0;
		m_Start = true;
	}
}
