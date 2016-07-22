using UnityEngine;
using System.Collections;

public class BlockGenerater : MonoBehaviour {
	//float width, height;
	int count = 0;
	public GameObject canvas;
	public GameObject basicBlock;
	// Use this for initialization
	void Start () {
		/*
		width = canvas.GetComponent<RectTransform> ().rect.width;
		height = canvas.GetComponent<RectTransform> ().rect.height;
		*/
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (count++ % 200 == 0) {
			var block = Instantiate (basicBlock);
			block.transform.SetParent(canvas.transform);
			block.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 1);
			block.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 1);
			block.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,30,100);
			block.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,30,100);
		}
	}
}
