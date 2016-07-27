using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitBlock : MonoBehaviour {
	public GameObject score;
	private Animator ani;
	//public GameObject Explorn;
	//private Rigidbody2D Bullet;
	// Use this for initialization
	void Start () {
		score = GameObject.Find("ScoreText");
		ani=GetComponent<Animator> ();

		//ani.playAutomatically = false;
		//ani.CrossFade ("test41");

		//Explorn = GameObject.Find ("Explosion");
		//Bullet = Explorn.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButton(0)) {
			OnMouseDown ();
		}*/

		/* on iPad
		if (Input.touchCount > 0) {
			print ("GET " + Input.touchCount.ToString () + " Touches");
			Touch[] touches = Input.touches;
			for (int i = 0; i < Input.touchCount; i++) {
				checkIfTouched (touches [i]);
			}
		}
		*/

		/* For Debug */
		if (Input.GetMouseButton (0)) {
			checkIfClicked ();
			//gameObject.GetComponent<Animation> ().Play("test40");

		}
	}

	public void OnTouched() {
		int scoreAdding = gameObject.GetComponent<HitBlockAnimation> ().GetScore ();
		score.GetComponent<ScoreController> ().AddScore (scoreAdding);
		ani.SetTrigger ("play");
		//Rigidbody2D clone;
		//clone = Instantiate(Bullet, GameObject.position, GameObject.rotation);  // Bullet是一个Rigidbody，被克隆的对象； 后面两项分别是克隆后的出生位置和发射方向；
		//clone.velocity = new Vector2(0, 0); // 分别表示在X,Y,Z轴方向上的速度
		//Destroy (gameObject);
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
		//RaycastHit hit;
		//RaycastHit2D hit2d = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up); 
		RaycastHit2D hit2d = Physics2D.Raycast(gameObject.transform.position, -Vector2.up); 
		//if(Physics.Raycast(ray, out hit, 1000)){
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
