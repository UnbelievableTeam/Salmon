using UnityEngine;
using System.Collections;

public class BlockGenerater : MonoBehaviour {
	//float width, height;
	public GameObject canvas;
	public GameObject basicBlock;
	public GameObject music;
	Level level;
	public TextAsset levelJson;
	int updateCount = 0;
	int nextBlockCount;
	int blockCount = 0;
	// Use this for initialization
	void Start () {
		/*
		width = canvas.GetComponent<RectTransform> ().rect.width;
		height = canvas.GetComponent<RectTransform> ().rect.height;
		*/ 
		level = Level.CreateFromJSON(levelJson.text);
		nextBlockCount = level.blocks [blockCount].time;
	}

	void FixedUpdate() {
		if (music.GetComponent<AudioSource>().enabled && blockCount < level.blocks.Length) {
			if (updateCount == nextBlockCount) {
				while (blockCount < level.blocks.Length && level.blocks [blockCount].time == updateCount) {
					instantiateFromBlock (level.blocks [blockCount]);
					blockCount += 1;
					if (blockCount < level.blocks.Length)
						nextBlockCount = level.blocks [blockCount].time;
				}
			}
			updateCount += 1;
		}
	}

	void instantiateFromBlock (Block blockData) {
		GameObject block = Instantiate(basicBlock);
		block.transform.SetParent(canvas.transform);
		block.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 1);
		block.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 1);
		block.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,blockData.left,100);
		block.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,blockData.top,100);
	}
}