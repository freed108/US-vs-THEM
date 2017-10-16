using UnityEngine;
using System.Collections;

public class Unit_Building : MonoBehaviour {

	public GameObject Selected;
	private GameObject Unit;
	public GameObject Unit1;
	public GameObject StrategyMode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (StrategyMode.activeSelf == true) {
			if(Selected.activeSelf == true)
			{
				if (Input.GetKeyDown (KeyCode.Alpha1)) {
					Unit = (GameObject)Instantiate(Unit1, this.transform.position, this.transform.rotation);
				}
			}
		}
	}
}
