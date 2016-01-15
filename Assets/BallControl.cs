using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour
{
	bool m_Selected = false;
	Vector3 m_Top = new Vector3 (0, 27, -50);
	Vector3 m_Bottom = Vector3.zero;
	Vector3 m_FinalPos = Vector3.zero;
	int m_Frame = 0;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_Selected) {
			if (m_Frame < 100) {
				this.transform.position = Vector3.Lerp (m_Bottom, m_Top, m_Frame / 59f);
				m_Frame++;
				return;
			}	
			this.transform.position = m_FinalPos;
			Quaternion quate = Quaternion.identity;
			this.transform.rotation = quate;
			this.transform.localScale = new Vector3 (5, 5, 5);
			m_Selected = false;
		}
	}

	void Select (int index)
	{
		m_Bottom = new Vector3 (0, this.transform.position.y, -50);
		//m_FinalPos = new Vector3 (-50 + 5 * (index % 5), -6.5f, -70 + 5 * (index / 5));
		m_FinalPos = GetPosition (index);
		Rigidbody rigidbody = this.GetComponent<Rigidbody> ();
		Destroy (rigidbody);
		m_Selected = true;
		m_Frame = 0;
	}

	Vector3 GetPosition (int index)
	{
		Vector3 m_Offset = new Vector3 (170, 0, 0);
		Vector3 result = Vector3.zero;
		if (index % 35 == 0) {
			result = new Vector3 (-110 + (index / 35) * 35, -43, -50) + m_Offset;
		} else {
			result = new Vector3 (-110 + (index % 5) * 5 + (index / 35) * 35, -43 + ((index % 35) / 5) * 10, -50 + ((index % 35) / 5) * 5) + m_Offset;
		}			
		return result;
	}
}
