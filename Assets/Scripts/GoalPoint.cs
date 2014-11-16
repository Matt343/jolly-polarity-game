using UnityEngine;
using System.Collections.Generic;

public class GoalPoint : MonoBehaviour {

	public bool Active = true;

	private List<GameObject> players = new List<GameObject>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log ("Players inside: " + players.Count);
		if (Active) {
			var objects = FindObjectsOfType<Hero> ();
			foreach(var o in objects)
				if(!players.Contains(o.gameObject))
					return;
			Application.LoadLevel (Application.loadedLevel+1);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		this.players.Add (other.gameObject);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		this.players.Remove (other.gameObject);
	}
}
