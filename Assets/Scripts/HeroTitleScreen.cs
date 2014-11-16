using UnityEngine;
using System.Collections;

public class HeroTitleScreen : MonoBehaviour {
	public float MaxSpeed;
	public float MoveForce;
	public GameObject GroundDetector;
	public GameObject ScreenEdgeDetector;
	public GameObject ProjectileEmitLocator;
	public GameObject Projectile;
	public Camera RenderingCamera;
	
	public float ForceStrength = 1f;

	private ForceGenerator forceGenerator;
	private MagneticObject magneticObject;

	private bool AtEdgeOfScreen = false;
	private bool FacingRight = true;
	
	void Start ()
	{
		this.forceGenerator = this.GetComponentInChildren<ForceGenerator> ();
		this.magneticObject = this.GetComponent<MagneticObject> ();

	}
	
	void Update ()
	{
		float viewportPointOfEdgeDetector = this.RenderingCamera.WorldToViewportPoint (this.ScreenEdgeDetector.transform.position).x;
		this.AtEdgeOfScreen = viewportPointOfEdgeDetector < 0.0f || viewportPointOfEdgeDetector >= 1.0f;
		
	}
	
	void FixedUpdate ()
	{
		float horizontal = 1;
		
		if (horizontal * this.rigidbody2D.velocity.x < this.MaxSpeed) {
			this.rigidbody2D.AddForce (Vector2.right * horizontal * MoveForce);
		}
		
		float maxSpeed = Mathf.Abs (this.MaxSpeed * horizontal);
		if (Mathf.Abs (this.rigidbody2D.velocity.x) > maxSpeed) {
			this.rigidbody2D.velocity = new Vector2 (Mathf.Sign (this.rigidbody2D.velocity.x) * maxSpeed, this.rigidbody2D.velocity.y);
		}
		
		this.forceGenerator.Active = true;
		this.magneticObject.Active = true;
	}
}
