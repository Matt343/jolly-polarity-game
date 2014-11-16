using UnityEngine;
using System.Collections.Generic;

public class PointChargeManager : MonoBehaviour {
	public float Rate = .1f;
	public GameObject PositivePointCharge;
	public GameObject NegativePointCharge;
	public float Size = 1f;
	public List<ForceGenerator> Generators;
	float time = 0;
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0) {
			time = Rate;

			foreach (var generator in Generators) {
				if (generator.Active) {
					var min = generator.collider2D.bounds.min;
					var size = generator.collider2D.bounds.extents * 2;
					Vector3 position = Vector3.zero;
					var rand = Random.Range (0, 2 * size.x + 2 * size.y);
					if (rand < size.y) { //left side
						position = new Vector3 (0, rand, 0);
					} else if (rand < size.y * 2) { //right side
						position = new Vector3 (size.x, rand - size.y, 0);
					} else if (rand < size.y * 2 + size.x) { //bottom side
						position = new Vector3 (rand - size.y * 2, 0, 0);
					} else { //top side
						position = new Vector3 (rand - (size.y * 2 + size.x), size.y, 0);
					}
					position += min;

					//var position = new Vector3 (Random.Range (min.x, max.x), Random.Range (min.y, max.y), 0);
					if (generator.ForceStrength > 0) {
						var point = Instantiate (PositivePointCharge, position, Quaternion.identity) as GameObject;
						point.transform.parent = transform;
					} else {
						var point = Instantiate (NegativePointCharge, position, Quaternion.identity) as GameObject;
						point.transform.parent = transform;
					}
				}
			}
		}
	}
}
