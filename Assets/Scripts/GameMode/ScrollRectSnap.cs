using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour {
	public RectTransform panel;
	public Button[] bttn;
	public RectTransform center;

	private float[] distance;
	private bool dragging = false; 
	private int bttnDistance;
	private int minButtonNum;

	void Start() {
		int bttnLength = bttn.Length;
		distance = new float[bttnLength];
		bttnDistance = (int)Mathf.Abs (bttn [1].GetComponent<RectTransform> ().anchoredPosition.y - bttn [0].GetComponent<RectTransform> ().anchoredPosition.y);
	}

	void Update() {
		for (int i = 0; i < bttn.Length; i++) {
			distance [i] = Mathf.Abs (center.transform.position.y - bttn [i].transform.position.y);
		}

		float minDistance = Mathf.Min (distance);

		for (int a = 0; a < bttn.Length; a++) {
			if (minDistance == distance [a]) {
				minButtonNum = a;
			}
		}
		if (!dragging) {
			LerpToBttn (minButtonNum * -bttnDistance);
		}
	}

	void LerpToBttn(int position){
		float newY = Mathf.Lerp (panel.anchoredPosition.y, position, Time.deltaTime * 5f);
		Vector2 newPosition = new Vector2 (newY, panel.anchoredPosition.y);

		panel.anchoredPosition = newPosition;
	}

	public void StartDrag() {
		dragging = true;
	}

	public void EndDrag() {
		dragging = false;
	}
}
 