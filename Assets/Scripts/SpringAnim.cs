using UnityEngine;
using System.Collections;

public class SpringAnim : MonoBehaviour {

	public GameObject SpringBase;
	public GameObject Spring;
	public int xy = 1; //x=0, y=1

	private float ratiox, ratioy;

	// Use this for initialization
	void Start () {
		ratiox = this.transform.localScale.x / this.transform.collider2D.bounds.size.x;
		ratioy = this.transform.localScale.y / this.transform.collider2D.bounds.size.y;

		if (xy == 1) {
			this.transform.localScale.Set(Spring.transform.collider2D.bounds.size.x * ratiox, 1, 1);
		} else {
			this.transform.localScale.Set(1, Spring.transform.collider2D.bounds.size.y * ratioy, 1);
		}
		//this.SpringBase = this.transform.parent.gameObject;
		//this.Spring = SpringBase.GetComponent(Spring);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		Adjust ();
	}

	void Adjust(){
		Vector3 avg = (Spring.transform.position + SpringBase.transform.position);
		avg.x /= 2;
		avg.y /= 2;
		float length;
		this.transform.position = avg;
		Vector3 scale;
		scale = this.transform.localScale;
		if(xy == 1){
			length = Spring.transform.position.y + Spring.collider2D.bounds.extents.y - SpringBase.transform.position.y;
			scale.y = length * ratioy;
		}else{
			length = Spring.transform.position.x + Spring.collider2D.bounds.extents.x - SpringBase.transform.position.x;
			scale.x = length * ratiox;
		}
		this.transform.localScale = scale;
	}
}
