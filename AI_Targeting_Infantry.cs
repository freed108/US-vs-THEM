using UnityEngine;
using System.Collections;

public class AI_Targeting_Infantry : MonoBehaviour {

	public Mouse_Point mouse;
	public Transform player;
	public GameObject target;
	public GameObject target2;
	public GameObject selected;
	public GameObject Standard;
	public float playerDistance;
	public float rotationDamping;
	public float moveSpeed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mouse.Target != null && selected.activeSelf == true) {
			player = mouse.Target.transform;
			target2.SetActive(true);
		} else if (player == null) {
			player = Standard.transform;
			target.SetActive (false);
			target2.SetActive (false);
		}

		playerDistance = Vector3.Distance (player.position, transform.position);
		
		lookAtPlayer();
		
		/*if (playerDistance > 5f && playerDistance < 20f) 
		{
			chase ();
		}*/
		
		/*if(Selected.activeInHierarchy == true)
		{
			player.transform.Translate(mouse.RightClickMarker, mouse.RightClickMarker, mouse.RightClickMarker);
		}*/
	}
	
	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}
	
	/*void chase()
	{
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
	}*/

	void OnTriggerEnter(Collider other)
	{
		if (target.activeSelf == false && target2.activeSelf == false) {
			if(other.transform.FindChild("Blue Army"))
			{
				player = other.transform;
				target.SetActive(true);
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (target.activeSelf == true && target2.activeSelf == false) {
			if(other.transform.FindChild("Blue Army"))
			{
				player = Standard.transform;
				target.SetActive(false);
			}
		}
	}
}
