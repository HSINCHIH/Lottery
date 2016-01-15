using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

public class PickBall : MonoBehaviour
{
	List<GameObject> m_Balls = new List<GameObject> ();
	List<GameObject> m_PickBalls = new List<GameObject> ();
	bool m_CanPick = true;
	int m_Frame = 0;
	// Use this for initialization
	DateTime m_StartTime;
	bool m_GlobalCanPick = false;
	int m_Interval = 200;
	Vector3 m_PickTop = new Vector3 (0, 8, 0);
	Vector3 m_PickBottom = new Vector3 (0, 5, 0);

	void Start ()
	{
		for (int i = 0; i < 70; i++) {
			m_Balls.Add (GameObject.Find (string.Format ("Ball_{0:00}", i + 1)));
		}
		m_StartTime = DateTime.Now;
		this.SendMessage ("SetInterval", m_Interval);
		this.SendMessage ("SetGlobalCanPick", m_GlobalCanPick);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			m_GlobalCanPick = m_GlobalCanPick ? false : true;
			this.SendMessage ("SetGlobalCanPick", m_GlobalCanPick);
		}
		if (Input.GetKeyDown (KeyCode.KeypadPlus)) {
			m_Interval += 5;
			m_Frame = 0;
			//Debug.Log (string.Format ("KeypadPlus"));
			this.SendMessage ("SetInterval", m_Interval);
		}
		if (Input.GetKeyDown (KeyCode.KeypadMinus)) {
			m_Interval -= 5;
			m_Frame = 0;
			//Debug.Log (string.Format ("KeypadMinus"));
			this.SendMessage ("SetInterval", m_Interval);
		}
		if (m_GlobalCanPick) {		
			if (m_CanPick) {
				GameObject lowestBall = null;
				float minY = float.MaxValue;
				foreach (GameObject go in m_Balls) {
					if (go.transform.position.y < minY) {
						lowestBall = go;
						minY = go.transform.position.y;
					}
				}
				//if (minY < 5.0f) {
				//	m_Balls.Remove (lowestBall);
				//	m_PickBalls.Add (lowestBall);
				//	lowestBall.SendMessage ("Select", m_PickBalls.Count - 1);
				//	//Debug.Log (string.Format ("Pick : {0}", lowestBall.name));
				//	this.SendMessage ("SetBallCount", m_Balls.Count);
				//	if (m_Balls.Count == 0) {
				//		TimeSpan interval = DateTime.Now - m_StartTime;
				//		Debug.Log (string.Format ("Use time : {0} ms", interval.TotalMilliseconds));
				//	}
				//	this.SendMessage ("PickBall", Int32.Parse (lowestBall.name.Split ('_') [1]));
				//}
				if (minY < Vector3.Lerp (m_PickBottom, m_PickTop, (m_PickBalls.Count / 10) / 7f).y) {
					m_Balls.Remove (lowestBall);
					m_PickBalls.Add (lowestBall);
					lowestBall.SendMessage ("Select", m_PickBalls.Count - 1);
					//Debug.Log (string.Format ("Pick : {0}", lowestBall.name));
					this.SendMessage ("SetBallCount", m_Balls.Count);
					if (m_Balls.Count == 0) {
						TimeSpan interval = DateTime.Now - m_StartTime;
						Debug.Log (string.Format ("Use time : {0} ms", interval.TotalMilliseconds));
						this.SendMessage ("SetUsageTime", interval.TotalMilliseconds.ToString ());
					}
					this.SendMessage ("PickBall", Int32.Parse (lowestBall.name.Split ('_') [1]));
				}
				m_CanPick = false;
				m_Frame = 0;
			} else {
				if (m_Frame > m_Interval / 2) {
					this.SendMessage ("CleanNotify");
				}
				if (m_Frame > m_Interval) {
					m_CanPick = true;
					Debug.Log (string.Format ("m_Frame : {0} ms", m_Frame));
				}
				m_Frame++;
			}
		}
	}
}
