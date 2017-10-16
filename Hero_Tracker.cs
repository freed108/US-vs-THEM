using UnityEngine;
using System.Collections;

public class Hero_Tracker : MonoBehaviour {

	public GameObject Hero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (Hero.transform.position.x, this.transform.position.y, (Hero.transform.position.z - 1));
	}
}
