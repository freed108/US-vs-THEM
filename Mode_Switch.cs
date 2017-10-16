using UnityEngine;
using System.Collections;

public class Mode_Switch : MonoBehaviour {

	public GameObject Third_Person_Camera;
	public GameObject Strategy_Camera;
	public GameObject Camera_Reset;
	public CharacterMotor Controller;
	public GameObject Strategy_Mode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if(Third_Person_Camera.activeSelf == true)
			{
				Third_Person_Camera.SetActive(false);
				Controller.SetControllable(false);
				Strategy_Camera.SetActive(true);
				Strategy_Mode.SetActive(true);
			}

			else
			{
				Third_Person_Camera.SetActive(true);
				Controller.SetControllable(true);
				Strategy_Camera.transform.position = new Vector3 (Camera_Reset.transform.position.x, Camera_Reset.transform.position.y, Camera_Reset.transform.position.z);
				Strategy_Camera.SetActive(false);
				Strategy_Mode.SetActive(false);
			}
		}
	}
}
