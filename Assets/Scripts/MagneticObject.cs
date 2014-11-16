using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class MagneticObject : MonoBehaviour {
	public float ForceStrength = 1f;
	public bool Active = true;
	public SpriteRenderer Sprite;
	public Color DefaultColor = Color.white;
	public Color PositiveColor = Color.blue;
	public Color NegativeColor = Color.red;

	private Color currentColor;

	void Start () {
		if (!this.Sprite) 
			this.Sprite = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		currentColor = Active ? (ForceStrength > 0 ? PositiveColor : NegativeColor) : DefaultColor;
		if (this.Sprite) 
			this.Sprite.color = currentColor;
	}
}
