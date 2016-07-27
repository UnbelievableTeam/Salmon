using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour {
	public RectTransform panel;
	public Button[] bttn;
	public RectTransform center;
	private float[] distance;
	private bool dragging = false;
	private int bttnDistance;
	private int minButtonNum;
	// Use this for initialization
	void Start () {
	//	int bttnLength = bttn.Length;
	//	distance = new float[bttnLength];

	//	bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform> ().anchoredPosition.y) - bttn [0].GetComponent<RectTransform> ().anchoredPosition.y;
	//	print (bttnDistance);

		int bttnLength = bttn.Length;
		distance = new float[bttnLength];
		bttnDistance = (int)Mathf.Abs (bttn [1].GetComponent<RectTransform> ().anchoredPosition.y - bttn [0].GetComponent<RectTransform> ().anchoredPosition.y);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < bttn.Length; i++) {
		//	distance[i] = Mathf.Abs (center.transform.position.y - bttn [i],transform.position.y);
			//distance [i] = Mathf.Abs (center.transform.position.y - bttn [i].transform.position.y);
		}
	}
}
