using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Health2 health;
	public float max_health = 100f;
	public float cur_health = 10f;
	public float calc_health = 1f;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		max_health = health.Max_Hitpoints;
		cur_health = max_health;
	}
	
	// Update is called once per frame
	void Update () {
		cur_health = health.Hitpoints;
		calc_health = cur_health / max_health;
		SetHealthBar (calc_health);
	}

	public void SetHealthBar(float myHealth)
	{
		healthBar.transform.localScale = new Vector3 (Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
