using UnityEngine;
using System.Collections;

public class SpringAnim : MonoBehaviour {

	public GameObject SpringBase;
	public GameObject Spring;
	private int xy = 1; //x=0, y=1

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
		//Vector3 avg = (Spring.transform.position + SpringBase.transform.position);
		Vector3 avg = Spring.transform.localPosition;
		avg /= 2;
		float length;
		avg.y += Spring.transform.collider2D.bounds.extents.y;
		this.transform.localPosition = avg;
		Vector3 scale;
		scale = this.transform.localScale;
	//	if(xy == 1){
			//length = Spring.transform.position.y + Spring.transform.collider2D.bounds.extents.y - SpringBase.transform.position.y;
		length = Spring.transform.localPosition.y / 2 + Spring.transform.collider2D.bounds.size.y;
		scale.y = length * ratioy;
	//	}else{
	//		length = Spring.transform.position.x + Spring.transform.collider2D.bounds.extents.x - SpringBase.transform.position.x;
	//		scale.x = length * ratiox;
	//	}
		this.transform.localScale = scale;
	}
}
