using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitBlock : MonoBehaviour {
	public GameObject score;
	// Use this for initialization
	void Start () {
		score = GameObject.Find("ScoreText");
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
		}
	}

	public void OnTouched() {
		int scoreAdding = gameObject.GetComponent<HitBlockAnimation> ().GetScore ();
		score.GetComponent<ScoreController> ().AddScore (scoreAdding);
		Destroy (gameObject);
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
