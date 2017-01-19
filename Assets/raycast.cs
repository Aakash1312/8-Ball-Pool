using UnityEngine;
using System.Collections;

public class raycast : MonoBehaviour {
	private GameObject refer;
	private GameObject cuestick;
	public RaycastHit finalHit;
	// Use this for initialization
	void Start () {
		refer = GameObject.Find ("Sphere");
		cuestick = GameObject.Find("Cylinder");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 axisofhit = refer.transform.position - cuestick.transform.position - new Vector3 (0, refer.transform.position.y - cuestick.transform.position.y, 0);
		RaycastHit[] g = Physics.RaycastAll (refer.transform.position, axisofhit);
		finalHit = new RaycastHit();
		float min = int.MaxValue;
		foreach (RaycastHit obj in g){
			if (obj.distance < min) {
				min = obj.distance;
				finalHit = obj;
			}
		}

		Vector3 center = (finalHit.point + refer.transform.position) / 2;
		transform.localScale = new Vector3 (0.2F, finalHit.distance/2, 0.2F);
		transform.up = axisofhit;
		transform.position = center;
	}
}
