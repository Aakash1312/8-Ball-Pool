using UnityEngine;
using System.Collections;

public class light5 : MonoBehaviour {

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("5");
		rb = g.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		transform.position = rb.transform.position;
	}
}
