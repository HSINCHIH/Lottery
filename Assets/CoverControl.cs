﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CoverControl : MonoBehaviour {

	List<Vector3> m_Orig = new List<Vector3>();
	List<GameObject> m_Objects = new List<GameObject>();
	bool m_Open = false;
	int m_Step = 0;
	GameObject m_CoverGroup = null;
	// Use this for initialization
	void Start (){
		m_CoverGroup = GameObject.Find ("CoverGroup");
		foreach (Transform transform in m_CoverGroup.transform) {
			m_Orig.Add (m_CoverGroup.transform.position - transform.position);
			m_Objects.Add (transform.gameObject);
		}
		for (int i = 0; i < m_Objects.Count; i++) {
			m_Objects [i].transform.position = m_CoverGroup.transform.position + (m_Orig [i] * 1) / 10;
		}
		m_Step = 10;
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.O)) {
		//	m_Open = m_Open ? false : true;
		//	m_Step = 0;
		//}
		//
		//if (m_Step < 10) {
		//	if (m_Open) {
		//		for (int i = 0; i < m_Objects.Count; i++) {
		//			m_Objects [i].transform.position = m_CoverGroup.transform.position + (m_Orig [i] * m_Step) / 10;
		//		}
		//	} else {
		//		for (int i = 0; i < m_Objects.Count; i++) {
		//			m_Objects [i].transform.position = m_CoverGroup.transform.position + (m_Orig [i] * (10 - m_Step )) / 10;
		//		}
		//	}
		//	m_Step++;
		//}
	}
}
