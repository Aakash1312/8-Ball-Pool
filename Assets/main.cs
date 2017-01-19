using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	private Rigidbody rb;
	private GameObject cuer;
	private cue cues;
	private bool jerked;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		cuer = GameObject.Find ("Cylinder");
		cues = cuer.GetComponent<cue> ();
		jerked = false;
	}
	public void jerk(){
		Vector3 o = cuer.transform.position;
		Vector3 c = rb.position;
		Vector3 forceVec = c - o - new Vector3(0, c.y - o.y, 0);
		float magnitude = forceVec.magnitude;
		rb.AddForce(forceVec.normalized * magnitude * magnitude * magnitude* magnitude* 0.00008F);
		jerked = true;
	}

	void FixedUpdate()
	{
		if (jerked) {
			if (rb.velocity.magnitude != 0) {
				StartCoroutine (cues.allstopped());
				jerked = false;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
