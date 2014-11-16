using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	private float timer;
	private bool called;

	// Use this for initialization
	void Start () {
		called = false;
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > 5.0f && !called) {
			Application.Quit ();
			called = true;
		}
	}
}
