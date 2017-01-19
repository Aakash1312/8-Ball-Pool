using UnityEngine;
using System.Collections;

public class raycast2 : MonoBehaviour {
	private GameObject firstRay;
	private raycast firstRayScript;
	// Use this for initialization
	void Start () {
		firstRay = GameObject.Find ("glowy");
		firstRayScript = firstRay.GetComponent<raycast> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit finalHit = firstRayScript.finalHit;
		Vector3 bodycenter = finalHit.transform.position;
		Vector3 axisofhit = firstRay.transform.up.normalized;
		Vector3 normal = finalHit.normal.normalized;
		//Vector3 finalRay = axisofhit - Vector3.Dot (axisofhit, normal) * normal;
		Vector3 endposition = bodycenter - 5 * normal;
		Vector3 position = (bodycenter + endposition) / 2;
		transform.up = normal;
		transform.position = position;
		transform.localScale = new Vector3 (0.2F, (bodycenter - endposition).magnitude/2, 0.2F);
	}
}
