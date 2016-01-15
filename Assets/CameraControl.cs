using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {
	List<GameObject> m_CameraList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		m_CameraList.Add (GameObject.Find ("Main Camera"));
		m_CameraList.Add (GameObject.Find (string.Format ("Camera_{0:00}", 1)));
		m_CameraList.Add (GameObject.Find (string.Format ("Camera_{0:00}", 2)));
		m_CameraList.Add (GameObject.Find (string.Format ("Camera_{0:00}", 3)));
		m_CameraList.Add (GameObject.Find (string.Format ("Camera_{0:00}", 4)));	
		DisableCamera ();
		m_CameraList [0].SetActive (true);
		m_CameraList [0].SendMessage ("Active");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad0)) {
			DisableCamera ();
			m_CameraList [0].SetActive (true);
			m_CameraList [0].SendMessage ("Active");
		}
		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			DisableCamera ();
			m_CameraList [1].SetActive (true);
			m_CameraList [1].SendMessage ("Active");
		}
		if (Input.GetKeyDown (KeyCode.Keypad2)) {
			DisableCamera ();
			m_CameraList [2].SetActive (true);
			m_CameraList [2].SendMessage ("Active");
		}
		if (Input.GetKeyDown (KeyCode.Keypad3)) {
			DisableCamera ();
			m_CameraList [3].SetActive (true);
			m_CameraList [3].SendMessage ("Active");
		}
		if (Input.GetKeyDown (KeyCode.Keypad4)) {
			DisableCamera ();
			m_CameraList [4].SetActive (true);
			m_CameraList [4].SendMessage ("Active");
		}
	}

	void DisableCamera()
	{
		foreach (GameObject obj in m_CameraList) {
			obj.SetActive (false);
		}
	}
}
