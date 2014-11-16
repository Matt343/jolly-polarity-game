using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(Collider2D))]
public class ForceGenerator : MonoBehaviour
{
	public float ForceStrength = 1f;
	public bool Active = false;

	public SpriteRenderer Sprite;
	public Color DefaultColor = Color.white;
	public Color PositiveColor = Color.blue;
	public Color NegativeColor = Color.red;

	private List<GameObject> intersecting = new List<GameObject> ();
	private Color currentColor;

	void Start ()
	{
		if (!this.Sprite) 
			this.Sprite = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		currentColor = Active ? (ForceStrength > 0 ? PositiveColor : NegativeColor) : DefaultColor;
		if (this.Sprite) 
			this.Sprite.color = currentColor;

		if (Active) {
			var objects = FindObjectsOfType<MagneticObject> ();
			foreach (var o in objects) {
				if (o.Active && o.gameObject != this.transform.parent.gameObject) {
					var displacement = o.transform.position - this.transform.position;
					var sqrDist = displacement.sqrMagnitude;
					if (sqrDist == 0)
						displacement = Vector2.one * .001f;

					var force = displacement.normalized * o.ForceStrength * this.ForceStrength / sqrDist;

					// Check if object is within min distance for attractive force
					if (Mathf.Abs (Vector2.Angle (force, displacement)) < 1f || !this.intersecting.Contains (o.gameObject)) {
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
