using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockGenerater : MonoBehaviour {
	float width, height;
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
		width = canvas.GetComponent<RectTransform> ().rect.width;
		height = canvas.GetComponent<RectTransform> ().rect.height;
		level = Level.CreateFromJSON(levelJson.text);
		nextBlockCount = level.blocks [blockCount].time;
		print (level.blocks.Length);
	}

	void FixedUpdate() {
		if (music.GetComponent<AudioSource>().enabled && blockCount < level.blocks.Length) {
			if (updateCount == nextBlockCount) {
				while (blockCount < level.blocks.Length && level.blocks [blockCount].time == updateCount) {
					if (level.blocks [blockCount] != null) {
						print ("Try to Instantiate " + blockCount.ToString () + "th Block, its sketchImg is " + level.blocks [blockCount].sketchName);
						instantiateFromBlock (level.blocks [blockCount]);
						blockCount += 1;
						if (blockCount < level.blocks.Length)
							nextBlockCount = level.blocks [blockCount].time;
					}
				}
			}
			updateCount += 1;
		}
	}

	void instantiateFromBlock (Block blockData) {
		GameObject block = Instantiate(basicBlock);
		float blockHW = 190 * 3;
		block.transform.SetParent(canvas.transform);
		block.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 1);
		block.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 1);
		block.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,width * blockData.left / 2048 - blockHW / 2,blockHW);
		block.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,height * blockData.top / 1536 - blockHW / 2,blockHW);
		Texture2D ball = Resources.Load ("Pictures/Balls/" + blockData.pointImg) as Texture2D;
		block.transform.GetChild (5).gameObject.GetComponent<Image> ().sprite = Sprite.Create(ball, new Rect(0,0, ball.width, ball.height), new Vector2(0.5f, 0.5f));
		block.GetComponent<HitBlock> ().sketchName = blockData.sketchName;
	}
}