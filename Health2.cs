using UnityEngine;
using System.Collections;

public class Health2 : MonoBehaviour {

	public EnergyShield Shield;
	public float Max_Hitpoints;
	public float Hitpoints;
	public GameObject body;

	// Use this for initialization
	void Start () {
		Hitpoints = Max_Hitpoints;
	}
	
	// Update is called once per frame
	void Update () {
		if (Hitpoints <= 0) {
			Destroy(body);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Laser(Clone)")
		{
			if (Shield.Shield_Energy <= 0) 
			{
				Hitpoints = Hitpoints - 5;
			}
		}
	}
}
