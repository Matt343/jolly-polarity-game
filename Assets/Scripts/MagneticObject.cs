using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class MagneticObject : MonoBehaviour
{

	public float ForceStrength = 1f;
	public bool Active = true;
}
