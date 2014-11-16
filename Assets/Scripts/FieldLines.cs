using UnityEngine;
using System.Collections.Generic;

struct PointForce {
	public Vector2 pos;
	public float strength;
}

public class FieldLines : MonoBehaviour { 
	public List<ForceGenerator> Generators = new List<ForceGenerator> ();
	public ComputeShader shader;
	RenderTexture tex;
	ComputeBuffer buffer;
	//ComputeBuffer outBuffer;

	const int count = 10;
	PointForce[] data = new PointForce[count];
	//Vector2[] outData = new Vector2[count];

	void Start () {
		tex = new RenderTexture (256, 256, 0);
		tex.enableRandomWrite = true;
		tex.Create ();

		shader.SetTexture (0, "tex", tex);

	}

	bool printed = false;
	void OnGUI () {
		int w = Screen.width / 2;
		int h = Screen.height / 2;
		int s = 512;

		buffer = new ComputeBuffer (count, sizeof(float) * 3, ComputeBufferType.Default);
		//outBuffer = new ComputeBuffer (count, sizeof(float) * 3, ComputeBufferType.Default);

		shader.SetInt ("count", Generators.Count);
		shader.SetFloats ("minP", new float[] {-20, -3 });
		shader.SetFloats ("maxP", new float[] {10, 10 });
		
		for (int i = 0; i < Generators.Count; i++) {
			var p = Generators [i].transform.position;
			data [i].pos = new Vector2 (p.x, p.y);
			data [i].strength = Generators [i].Active ? Generators [i].ForceStrength : 0;
			if (!printed)
				Debug.Log (data [i].pos.ToString () + ", " + data [i].strength);
		}


		buffer.SetData (data);

		shader.SetBuffer (0, "points", buffer);
		//shader.SetBuffer (0, "outBuffer", outBuffer);
		shader.Dispatch (0, tex.width / 8, tex.height / 8, 1);

//		outBuffer.GetData (outData);
//
//		for (int i = 0; i < Generators.Count; i++) {
//			if (!printed)
//				Debug.Log (outData [i]);
//		}
		printed = true;

		buffer.Release ();
		//outBuffer.Release ();

		GUI.DrawTexture (new Rect (w - s / 2, h - s / 2, s, s), tex);
	}

	void OnDestroy () {
		tex.Release ();
	}
//	
//	// Update is called once per frame
//	void Update () {
//		for (int x = 0; x < 5; x++) {
//			for (int y = 0; y < 5; y++) {
//				drawLine (new Vector2 ((float)x, (float)y), 1);
//			}
//		}
//			
//	}
//
//	void drawLine (Vector2 start, int direction, float step = .01f, float maxDist = 200f) {
//		var p0 = start;
//		var dP = Vector2.zero;
//		var min = 0f;
//		var max = 0f;
//		do {
//			drawPoint (p0, Color.white);
//			minMaxDist (p0, ref min, ref max);
//			var E = calcField (p0 + .5f * dP);
//			var strength = E.magnitude;
//			if (strength > .01f)
//				return;
//			dP = direction * step * E / strength;
//			p0 += dP;
//		} while (min > 2f * step && max < maxDist);
//	}
//
//	void drawPoint (Vector2 p, Color color) {
//
//	}
//
//	void minMaxDist (Vector2 p, ref float min, ref float max) {
//		min = float.PositiveInfinity;
//		max = float.NegativeInfinity;
//		foreach (var g in this.Generators) {
//			var dist = (g.transform.position - this.transform.position).magnitude;
//			min = dist < min ? dist : min;
//			max = dist > max ? dist : max;
//		}
//	}
//
//	Vector2 calcField (Vector2 p) {
//		var field = Vector3.zero;
//		foreach (var g in this.Generators) {
//			var disp = g.transform.position - this.transform.position;
//			field += disp * g.ForceStrength / disp.sqrMagnitude;
//		}
//		return new Vector2 (field.x, field.y);
//	}
}
