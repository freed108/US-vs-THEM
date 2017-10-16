var player : GameObject;
var projectile : Rigidbody;
var speed = 10;
var playerDistance = 12;

function Update () {
	print (player.position);
	print (transform.position);
	playerDistance = Vector3.Distance (player.transform.position, transform.position);

	if (playerDistance <= 10)
	{
		clone = Instantiate(projectile, transform.position, transform.rotation);
		clone.velocity = transform.TransformDirection(Vector3 (0, 0, speed));

		Destroy (clone.gameObject, 5);
	}
}