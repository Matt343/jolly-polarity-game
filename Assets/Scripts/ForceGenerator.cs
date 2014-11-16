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
				if (o.Active && o.gameObject != this.transform.parent.gameObject) {
					//var displacement = o.transform.position - this.transform.position;
					var displacement = o.collider2D.bounds.center - this.collider2D.bounds.center;

					Vector3 target = o.collider2D.bounds.extents;
					Vector3 acting = this.collider2D.bounds.extents;
					acting += target;
					acting.x -= 0.8f;
					acting.y -= 0.8f;

					displacement.x = (displacement.x > acting.x) ? displacement.x - acting.x : 
						((displacement.x < -acting.x) ? displacement.x + acting.x : 0);
					displacement.y = (displacement.y > acting.y) ? displacement.y - acting.y : 
						((displacement.y < -acting.y) ? displacement.y + acting.y : 0);

					var sqrDist = displacement.sqrMagnitude;
					if (sqrDist == 0)
						displacement = Vector2.one * .001f;

					var force = displacement.normalized * o.ForceStrength * this.ForceStrength / sqrDist;

					// Check if object is within min distance for attractive force
					if (sqrDist > 0.2f && (Mathf.Abs (Vector2.Angle (force, displacement)) < 1f || !this.intersecting.Contains (o.gameObject))) {
						o.rigidbody2D.AddForce (force);
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
