using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class cue : MonoBehaviour {
	private Rigidbody sp;
	public Vector3 initialPosition;
	private GameObject cam;
	public Quaternion camRotation;
	private master masterScript;
	// Use this for initialization
	void Start () {
		GameObject t = GameObject.Find("Sphere");
		sp = t.GetComponent<Rigidbody> ();
		initialPosition = transform.position;
		cam = GameObject.Find ("Main Camera");
		masterScript = gameObject.GetComponent<master> ();
	}
	public void move(float value)
	{
		Vector3 temp = initialPosition - (transform.up * value * 30);
		transform.position = temp;
	}
	public IEnumerator allstopped(){
		Rigidbody[] GOS = FindObjectsOfType (typeof(Rigidbody)) as Rigidbody[];
		bool allSleeping = false;
		while (!allSleeping) {
			allSleeping = true;
			foreach (Rigidbody GO in GOS) {
				if (!(GO.velocity.magnitude == 0)) {
					allSleeping = false;
					yield return null;
					break;
				}
			}

		}
		transform.position = sp.transform.position - (transform.up.normalized * 60);
		initialPosition = transform.position;
		Vector3 tempcampos = transform.position + 30 * transform.up;
		cam.transform.position = new Vector3 (tempcampos.x + 3, 1, tempcampos.z);
		cam.transform.rotation = camRotation;
		GameObject[] trash = GameObject.FindGameObjectsWithTag ("tobedeleted");
		bool success = true;
		if (trash != null) {
			foreach (GameObject g in trash) {
				success = success && masterScript.remove (g.name);
			}
		}
	}
	void FixedUpdate()
	{
	}
	// Update is called once per frame
	void Update () {
	}
}
