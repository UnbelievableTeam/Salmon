using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitBlock : MonoBehaviour {
	public GameObject score;
	public GameObject sketchImage;
	public GameObject canvas;
	public string sketchName;
	// Use this for initialization
	void Start () {
		score = GameObject.Find("ScoreText");
		canvas = GameObject.Find ("SketchSpace");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			checkIfClicked ();
			//gameObject.GetComponent<Animation> ().Play("test40");

		}
	}

	public void OnTouched() {
		int scoreAdding = gameObject.GetComponent<HitBlockAnimation> ().GetScore ();
		score.GetComponent<ScoreController> ().AddScore (scoreAdding);
		loadBlockSketch ();
		//ani.SetTrigger ("play");
		//Rigidbody2D clone;
		//clone = Instantiate(Bullet, GameObject.position, GameObject.rotation);  // Bullet是一个Rigidbody，被克隆的对象； 后面两项分别是克隆后的出生位置和发射方向；
		//clone.velocity = new Vector2(0, 0); // 分别表示在X,Y,Z轴方向上的速度
		Destroy (gameObject);
	}

	void loadBlockSketch() {
		GameObject image = Instantiate(sketchImage);
		var rect = canvas.GetComponent<RectTransform> ().rect;
		image.transform.SetParent(canvas.transform);
		image.transform.localScale = Vector3.one;
		image.GetComponent<RectTransform> ().sizeDelta = Vector2.zero;
		image.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 1);
		image.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 1);
		image.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,0, rect.width);
		image.GetComponent<RectTransform> ().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,0, rect.height);
		Texture2D ball = Resources.Load ("Levels/1/sketch/" + sketchName) as Texture2D;
		Debug.Log (ball);
		image.GetComponent<Image> ().sprite = Sprite.Create(ball, new Rect(0,0, ball.width, ball.height), new Vector2(0.5f, 0.5f));
	}

	void checkIfTouched(Touch th) {
		if (th.phase == TouchPhase.Began) {
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(th.position.x, th.position.y, 0));
			ifRayHit (ray);
		}
	}

	void checkIfClicked() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		ifRayHit (ray);
	}

	void ifRayHit(Ray ray) {
		RaycastHit2D hit2d = Physics2D.Raycast(gameObject.transform.position, -Vector2.up); 
		print(hit2d);
		if(hit2d.collider != null) {
			print ("HIT");
			Debug.DrawLine(ray.origin, hit2d.point);
			GameObject obj = hit2d.transform.gameObject;
			if(obj.Equals(gameObject)) {
				OnTouched ();
			}
		}
	}
}
