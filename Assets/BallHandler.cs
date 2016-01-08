using UnityEngine;
using System.Collections;

public class BallHandler : MonoBehaviour {
	bool m_Selected = false;
	Vector3 m_Position = new Vector3 (0, 0, 0);
	int m_Count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (m_Selected) {
			if (m_Count > 100) {
				this.transform.position = m_Position;
				Quaternion quate = Quaternion.identity;
				this.transform.rotation = quate;
				m_Selected = false;
			}
			m_Count++;
		}
	}

	void Select(int index)
	{
		m_Position = new Vector3 (-50 + index * 5, 0, -70);
		this.transform.position = new Vector3 (0, 25, -50);
		Rigidbody rigidbody = this.GetComponent<Rigidbody> ();
		Destroy (rigidbody);
		m_Selected = true;
	}
}
