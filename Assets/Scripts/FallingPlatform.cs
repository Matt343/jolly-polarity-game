using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	public float dropTime;
	private bool fallTrigger;

	// Use this for initialization
	void Start () {
		fallTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (fallTrigger) {
			dropTime -= Time.deltaTime;
		}

		if (dropTime < 0.0f) {
			fallTrigger = false;
			this.gameObject.transform.parent.GetComponentInParent<Rigidbody2D>().isKinematic = false;
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.GetComponentInParent<Hero> () != null) {
			fallTrigger = true;
		}
	}

}
