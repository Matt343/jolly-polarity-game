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
					var angle = Random.value * Mathf.PI * 2;
					var rand = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle)) * Size;
					var position = new Vector3 (rand.x, rand.y, 0) + generator.transform.position;
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
