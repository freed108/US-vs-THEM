using UnityEngine;
using System.Collections;

public class Turret_Rotation : MonoBehaviour {

	public Transform player;
	public GameObject target;
	public GameObject target2;
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

	void OnTriggerEnter(Collider other)
	{
		if (target.activeSelf == false && target2.activeSelf == false) {
			if(other.transform.FindChild("Red Army"))
			{
				player = other.transform;
				target.SetActive(true);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (target.activeSelf == true && target2.activeSelf == false) {
			if(other.transform.FindChild("Red Army"))
			{
				player = null;
				target.SetActive(false);
			}
		}
	}
}
