using UnityEngine;
using System.Collections;

public class Health_Bar_Camera_Adjustment : MonoBehaviour {

	public Transform player;
	public GameObject Action_Lens;
	public GameObject Strategy_Lens;
	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Action_Lens.activeSelf == true) {
			player = Action_Lens.transform;
		} else {
			player = Strategy_Lens.transform;
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
