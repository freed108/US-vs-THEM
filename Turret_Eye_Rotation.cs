using UnityEngine;
using System.Collections;

public class Turret_Eye_Rotation : MonoBehaviour {

	public Turret_Rotation TR;
	public Transform player;
	public GameObject shoot;
	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		player = TR.player;

		if (player != null) {
			shoot.SetActive(true);
		}

		if (player == null) {
			shoot.SetActive(false);
		}

		playerDistance = Vector3.Distance (player.position, transform.position);
		
		lookAtPlayer();
	}

	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}
}
