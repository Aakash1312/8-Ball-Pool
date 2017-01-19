using UnityEngine;
using System.Collections;
public class touching : MonoBehaviour {
	private GameObject[] floors;
	// Use this for initialization
	void Start () {
		floors = GameObject.FindGameObjectsWithTag ("floors");
	}
	void OnCollisionEnter(Collision c)
	{
		foreach (GameObject floor in floors) {
			Collider floorCollider = floor.GetComponent<Collider> ();
			if (floorCollider.Equals (c.collider)) {
				gameObject.tag = "tobedeleted";
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
