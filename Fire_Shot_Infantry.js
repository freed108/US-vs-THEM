var target : GameObject;
var target2 : GameObject;
var projectile : Rigidbody;
var speed = 10;

var timer : float = 0.0;
var delay : float = 0.5;
var canFire = 1;

function Update () {
	timer -= Time.deltaTime;
	if(timer <= 0)
	{
		canFire = 1;
	}
	if (target.activeSelf == true || target2.activeSelf == true)
	{
		if(canFire == 1)
		{
			clone = Instantiate(projectile, transform.position, transform.rotation);
			clone.velocity = transform.TransformDirection(Vector3 (0, 0, speed));
			
			
			timer = delay;
			canFire = 0;
			
			Destroy (clone.gameObject, 5);
		}
	}
}