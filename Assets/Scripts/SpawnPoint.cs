using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public Hero player = null;

	// Use this for initialization
	void Start () {
		
	}
	
	public void respawn() {
		player.transform.position = this.transform.position;
	}
}
