using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(Collider2D))]
public class ForceGenerator : MonoBehaviour
{
	public float ForceStrength = 1f;
	public bool Active = false;

	private List<GameObject> intersecting = new List<GameObject> ();

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Active) {
			var objects = FindObjectsOfType<MagneticObject> ();
			foreach (var o in objects) {
				if (o.gameObject != this.transform.parent.gameObject) {
					MagneticObject m = o as MagneticObject;
					var displacement = m.transform.position - this.transform.position;
					var sqrDist = displacement.sqrMagnitude;
					if (sqrDist == 0)
						displacement = Vector2.one * .001f;

					var force = displacement.normalized * m.ForceStrength * this.ForceStrength / sqrDist;

					// Check if object is within min distance for attractive force
					if (Mathf.Abs (Vector2.Angle (force, displacement)) < 1f || !this.intersecting.Contains (m.gameObject)) {
						m.rigidbody2D.AddForce (force);
					}
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		this.intersecting.Add (other.gameObject);
	}

	void OnTriggerExit2D (Collider2D other)
	{
		this.intersecting.Remove (other.gameObject);
	}


}
