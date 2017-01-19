using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ball
{
	public int id;
	public GameObject g;
	public void remove()
	{
		g.SetActive (false);
	}
}
public class strip : ball {
	void Start()
	{
		id = 0;
	}
}
public class solid : ball {
	void Start()
	{
		id = 1;
	}
}
public class cueball : ball{
	void Start()
	{
		id = 2;
	}
}
public class master : MonoBehaviour {
	private Dictionary<string, solid> solids;
	private Dictionary<string, strip> strips;
	private foul foulScript;
	public bool isFirstPlayer;
	// Use this for initialization
	void Start () {
		solids = new Dictionary<string, solid>();
		strips = new Dictionary<string, strip>();
		GameObject tg = GameObject.Find ("Foul");
		foulScript = tg.GetComponent<foul> ();
		isFirstPlayer = true;
		GameObject[] temp = GameObject.FindGameObjectsWithTag ("solids") as GameObject[];
		Debug.Log ("s");
		foreach (GameObject g in temp) {
			solids [g.name] = new solid();
			solids [g.name].g = g;
			Debug.Log (g.name);
		}
		Debug.Log ("t");
		temp = GameObject.FindGameObjectsWithTag ("strips") as GameObject[];
		foreach (GameObject g in temp) {
			strips [g.name] = new strip();
			strips [g.name].g = g;
			Debug.Log (g.name);
		}
		//cue.g = GameObject.Find ("Sphere");
	}
	public bool remove(string name)
	{
		if (name.StartsWith ("o")) {
			if (isFirstPlayer) {
				Debug.Log ("sa1");
				Debug.Log (solids[name]);
				Debug.Log ("ea1");
				solids [name].remove ();
				return true;
			} else {
				isFirstPlayer = !isFirstPlayer;
				foulScript.start = true;
				return false;
			}
		} else {
			if (!isFirstPlayer) {
				Debug.Log ("sa");
				Debug.Log (strips[name]);
				Debug.Log ("ea");
				strips [name].remove ();
				return true;
			} else {
				isFirstPlayer = !isFirstPlayer;
				foulScript.start = true;
				return false;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
