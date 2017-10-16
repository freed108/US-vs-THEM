using UnityEngine;
using System.Collections;

public class Move_Spot_Adjustment : MonoBehaviour {

	int n;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.FindChild("Move Spot"))
		{
			n = Random.Range(1,4);
			if(n == 1)
			{
				transform.position = new Vector3((transform.position.x + 20), transform.position.y, transform.position.z);
			}

			else if(n == 2)
			{
				transform.position = new Vector3((transform.position.x - 20), transform.position.y, transform.position.z);
			}

			else if(n == 3)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + 20));
			}

			else if(n == 4)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z - 20));
			}
		}
	}
}
