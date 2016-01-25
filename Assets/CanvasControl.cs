using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CanvasControl : MonoBehaviour
{
	bool m_GlobalCanPick = false;
	bool m_ShowSystemInfo = true;
	int m_Interval = 0;
	string m_UseTime = "";
	List<int> m_BallPicked = new List<int> ();
	string m_SavePath = "";
	int m_Frame = 0;
	DateTime m_StartTime = DateTime.Now;
	double m_FPS = 0.0f;
	// Use this for initialization
	void Start ()
	{
		m_SavePath = Path.Combine (Directory.GetCurrentDirectory (), "Log.txt");
		if (File.Exists (m_SavePath)) {
			File.Delete (m_SavePath);
		}
		m_StartTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.I)) {
			m_ShowSystemInfo = m_ShowSystemInfo ? false : true;
			ShowSystemInfo (m_ShowSystemInfo);
		}
		TimeSpan timeSpan = (DateTime.Now - m_StartTime);
		if (timeSpan.TotalMilliseconds > 1000) {
			m_FPS =	(m_Frame * 1000) / timeSpan.TotalMilliseconds;
			m_Frame = 0;
			m_StartTime = DateTime.Now;
			ShowSystemInfo (m_ShowSystemInfo);
		}
		m_Frame++;
	}

	void PickBall (int number)
	{
		File.AppendAllText (m_SavePath, string.Format ("{0:00} ", number));
		m_BallPicked.Add (number);
		ShowNotify (number);
		string info = GetPickBallInfo ();
		GameObject canvas = GameObject.Find ("Canvas_Result");
		canvas.GetComponent<Text> ().text = info;
	}

	void SetInterval (int interval)
	{
		m_Interval = interval;	
		ShowSystemInfo (m_ShowSystemInfo);
	}

	void SetGlobalCanPick (bool onOff)
	{
		m_GlobalCanPick = onOff;
		ShowSystemInfo (m_ShowSystemInfo);
	}

	string GetPickBallInfo ()
	{
		List<int> pickOrder = new List<int> ();
		StringBuilder sb = new StringBuilder ();
		sb.Append ("按 開 獎 順 序\r\n");
		for (int i = 0; i < m_BallPicked.Count; i++) {
			if (i % 5 == 0) {
				sb.Append (string.Format ("{0:00} ~ {1:00} : ", (i / 5) * 5 + 1, (i / 5) * 5 + 5));
			}
			sb.Append (string.Format ("{0:00}  ", m_BallPicked [i]));
			if (i % 5 == 4) {
				sb.Append ("\r\n");
			}	
		}
		sb.Append ("\r\n\r\n");
		pickOrder.AddRange (m_BallPicked.ToArray ());
		pickOrder.Sort ();
		sb.Append (string.Format ("按 大 小 順 序"));
		for (int i = 0; i < pickOrder.Count; i++) {
			if (i % 10 == 0) {
				sb.Append ("\r\n");
			}
			sb.Append (string.Format ("{0:00}  ", pickOrder [i]));
		}
		return sb.ToString ();
	}

	void ShowSystemInfo (bool onOff)
	{
		StringBuilder sb = new StringBuilder ();
		if (onOff) {			
			sb.Append (string.Format ("FPS : {0:0.00}\r\n", m_FPS));
			sb.Append (string.Format ("開 獎 狀 態 : {0}\r\n", m_GlobalCanPick ? "Start" : "Stop"));
			sb.Append (string.Format ("開 獎 間 隔 : {0}\r\n", m_Interval));
			if (m_UseTime != "") {
				sb.Append (string.Format ("花 費 時 間 : {0}\r\n", m_UseTime));
			}
		}
		GameObject canvas = GameObject.Find ("Canvas_SystemInfo");
		canvas.GetComponent<Text> ().text = sb.ToString ();
	}

	void ShowNotify (int number)
	{
		GameObject canvas = GameObject.Find ("Canvas_NotifyTitle");
		canvas.GetComponent<Text> ().text = string.Format ("\r\n現 在 開 出 號 碼");
		canvas = GameObject.Find ("Canvas_NotifyNumber");
		canvas.GetComponent<Text> ().text = string.Format ("\r\n{0:00}", number);
	}

	void CleanNotify ()
	{
		GameObject canvas = GameObject.Find ("Canvas_NotifyTitle");
		canvas.GetComponent<Text> ().text = "";
		canvas = GameObject.Find ("Canvas_NotifyNumber");
		canvas.GetComponent<Text> ().text = "";
	}

	void SetUsageTime (string msUseTime)
	{
		m_UseTime = msUseTime;
		ShowSystemInfo (m_ShowSystemInfo);
	}
}
