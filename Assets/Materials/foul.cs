using UnityEngine;
using System.Collections;

public class foul : MonoBehaviour {
	int i = 0;
	public bool start = false;
	GameObject g;
	// Use this for initialization
	void Start () {
		g = GameObject.Find ("Foul");
		g.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		if (start) {
			Debug.Log ("foulstart");
			if (i == 1000) {
				start = false;
				i = 0;
				g.SetActive (false);
			} else {
				if (i == 0) {
					g.SetActive (true);
				}
				i++;
			}
		}
	}
}
