using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public GameObject a;
	public GameObject b;
	public GameObject c;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(a.transform.position,b.transform.position) >= 150)
		{
			a.GetComponentInParent<Renderer> ().material.color = Color.red;
		}
	}
}
