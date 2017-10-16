using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	public Transform player;
	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerDistance = Vector3.Distance (player.position, transform.position);
		
		lookAtPlayer();
	}
	
	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}
}
