using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour {

	public SpawnPoint sp = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other) {
		// If the hero hits spikes, kill both and respawn
		/*if(other.gameObject.GetComponent<Spikes>() != null) {
			var objects = FindObjectsOfType<Hero> ();
			foreach( var o in objects) {
				o.gameObject.GetComponent<HeroCollisions>().respawn();
			}
		}*/
	}

	public void respawn() {
		// Respawn the player at the correct position
		this.gameObject.transform.position = sp.transform.position;
	}
}
