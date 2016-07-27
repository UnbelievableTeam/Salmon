using UnityEngine;
using System.Collections;

public class HitBlockAnimation : MonoBehaviour {
	public float initialScale = 0;
	public float growingSpeed = 20;
	public GameObject animatedImage;
	Animation anim;
	public bool isStop = false;
	// Use this for initialization
	void Start () {
		animatedImage.GetComponent <RectTransform>().localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isStop && animatedImage.GetComponent<RectTransform> ().localScale.x < 1.0) {
			Growing (growingSpeed);
		} else {
			Touched ();
		}
	}

	void Growing(float speed) {
		animatedImage.GetComponent <RectTransform>().localScale += new Vector3 (1 / speed, 1 / speed, 0);
	}

	public void Touched() {
		if (!isStop) {
			//Destroy (this.gameObject);
		} else {
			//Destroy (this.gameObject);
		}
		Destroy (this.gameObject);
	}

	public void Stop() {
		isStop = true;
	}

	public void Resume() {
		isStop = false;
	}

	public int GetScore() {
		float size = animatedImage.GetComponent<RectTransform> ().localScale.x;
		int score = 0;
		if (size >= 0.3 && size < 0.8) {
			score = 40;
		} else if (size >= 0.8 && size < 0.95) {
			score = 80;
		} else if (size > 0.95) {
			score = 100;
		}
		//anim = gameObject.GetComponent<Animation>();
		//anim.Play ();
		isStop = true;
		return score;
	}
}