using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.GetComponent<Hero> () != null) {
			// Respawn the player
			//other.gameObject.GetComponent<HeroManager> ().respawn ();
		
			// For now, respawn both players
			var objects = FindObjectsOfType<Hero>();
			foreach (var o in objects)
				o.gameObject.GetComponent<HeroManager> ().respawn ();
		}
	}
}
