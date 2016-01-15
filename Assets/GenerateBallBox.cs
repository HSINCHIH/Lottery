using UnityEngine;
using System.Collections;

public class GenerateBallBox : MonoBehaviour
{
	Vector3 m_Offset = new Vector3 (170, 0, 0);
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < 14; i++) {			
			GameObject go = GameObject.CreatePrimitive (PrimitiveType.Cube);
		
			if (i % 7 == 0) {
				go.transform.position = new Vector3 (-100 + (i / 7) * 35, -47.5f, -50 + 5 * (i % 7)) + m_Offset;
				go.transform.localScale = new Vector3 (25, 5, 5);
			} else {
				go.transform.position = new Vector3 (-100 + (i / 7) * 35, -50f + 10 * (i % 7), -50 + 5 * (i % 7))+ m_Offset;
				go.transform.localScale = new Vector3 (25, 10, 5);
			}
		}
		for (int i = 0; i < 70; i++) {
			GameObject ban = GameObject.CreatePrimitive (PrimitiveType.Cube);
			ban.name = string.Format ("BAN_{0:00}", i + 1);
			string fileName = string.Format (@"Number\{0:00}", i + 1);
			Renderer rend = ban.GetComponent<Renderer> ();
			rend.material.mainTexture = Resources.Load (fileName) as Texture;
			rend.material.SetTextureScale ("_MainTex", new Vector2 (-1, -1));
			ban.transform.localScale = new Vector3 (5, 5, 0.1f);

			if (i % 35 == 0) {
				ban.transform.position = new Vector3 (-110 + (i / 35) * 35, -43, -50)+ m_Offset;
			} else {
				ban.transform.position = new Vector3 (-110 + (i % 5) * 5 + (i / 35) * 35, -43 + ((i % 35) / 5) * 10, -50 + ((i % 35) / 5) * 5)+ m_Offset;
			}
			ban.transform.position = ban.transform.position + new Vector3 (0, -4.5f, -2.6f);
		}	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
