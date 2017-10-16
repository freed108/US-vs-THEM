#pragma strict

var timer : float = 2.0;

function Update () {
	timer -= Time.deltaTime;
	
	if(timer <= 0)
	{
		Destroy (gameObject);
	}
}