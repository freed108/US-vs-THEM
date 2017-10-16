using UnityEngine;
using System.Collections;

public class EnergyShield : MonoBehaviour {

	public float Max_Shield_Energy;
	public float Shield_Energy;
	public GameObject body;
	public float Recharge_Timer;
	public float Recharge;
	public float Need_Recharge;
	public float Recharge_Rate = 1;

	// Use this for initialization
	void Start () {
		Shield_Energy = Max_Shield_Energy;
		Recharge_Timer = Recharge;
	}
	
	// Update is called once per frame
	void Update () {
		if (Need_Recharge == 1) {
			Recharge_Timer = Recharge_Timer - Time.deltaTime;
		}

		if (Recharge_Timer <= 0) {
			Need_Recharge = 0;
			Shield_Energy = 0;
			Recharge_Timer = Recharge;
		}

		if (Need_Recharge == 0 && Shield_Energy < Max_Shield_Energy) {
			Shield_Energy = Shield_Energy + (Time.deltaTime * Recharge_Rate);
		}

		if (Shield_Energy < 0 && Need_Recharge == 0) 
		{
			Need_Recharge = 1;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Laser(Clone)")
		{
			if(Shield_Energy > 0)
			{
				Shield_Energy = Shield_Energy - 5;
			}
		}
	}
}
