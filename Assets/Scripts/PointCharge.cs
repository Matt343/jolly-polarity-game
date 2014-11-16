using UnityEngine;
using System.Collections;

public class PointCharge : MonoBehaviour {
	public float Lifetime = 3f;
	public TrailRenderer trail;
	

	// Update is called once per frame
	void Update () {
		Lifetime -= Time.deltaTime;
		if (Lifetime < 0) 
			Destroy (gameObject);
	}

	void OnDestroy () {
		trail.transform.parent = transform.parent;
		trail.autodestruct = true;
	}
}
