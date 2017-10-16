using UnityEngine;
using System.Collections;

public class Enemy_Unit_Building_Tanks : MonoBehaviour {
	
	private GameObject Unit;
	public GameObject Unit1;
	public float Timer = 10.0f;
	public float Spawn_Delay = 20.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer <= 0) {
			Unit = (GameObject)Instantiate(Unit1, this.transform.position, this.transform.rotation);
			Timer = Spawn_Delay;
		}
		Timer -= Time.deltaTime;
	}
}
