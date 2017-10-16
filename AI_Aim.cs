using UnityEngine;
using System.Collections;

public class AI_Aim : MonoBehaviour {

	public AI_Targeting_Infantry aim_assist;
	public Transform player;
	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player = aim_assist.player.transform;

		playerDistance = Vector3.Distance (player.position, transform.position);
		
		lookAtPlayer();
	}
	
	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}
}
