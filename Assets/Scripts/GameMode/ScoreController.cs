using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour {
	public int score = 0;
	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text> ().text = "Score: " + this.score.ToString ();
	}

	public void AddScore(int adding) {
		score += adding;
	}
}
