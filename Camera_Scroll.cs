using UnityEngine;
using System.Collections;

public class Camera_Scroll : MonoBehaviour {

	public float m_speed = 20.0f;
	
	private Rigidbody m_rigidBody;
	
	// Use this for initialization
	void Start () {
		if (GetComponent<Rigidbody>() == null)
		{
			initRigidBody();
		}
		else
		{
			m_rigidBody = GetComponent<Rigidbody>();
		}
	}
	
	private void initRigidBody()
	{
		m_rigidBody = gameObject.AddComponent<Rigidbody>();
		m_rigidBody.mass = 500;
		m_rigidBody.interpolation = RigidbodyInterpolation.Interpolate;
		m_rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
		m_rigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		float translation = Input.GetAxis ("Horizontal") * m_speed;
		float translation2 = Input.GetAxis ("Vertical") * m_speed;
		
		// Make it move m_speed meters per second instead of m_speed meters per frame...
		//translation *= Time.deltaTime;
		
		// Move translation along the object's x-axis
		//transform.Translate (translation, 0, 0);
		
		m_rigidBody.velocity = new Vector3(translation, 0, translation2);
	}
}
