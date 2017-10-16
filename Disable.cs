using UnityEngine;
using System.Collections;

public class Disable : MonoBehaviour {

	public GameObject Third_Person_Camera;
	public GameObject FireSpot1;
	public GameObject FireSpot2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Third_Person_Camera.activeSelf == true) {
			FireSpot1.SetActive (true);
			FireSpot2.SetActive (true);
		} else {
			FireSpot1.SetActive(false);
			FireSpot2.SetActive(false);
		}
	}
}
