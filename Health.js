var Max_Hitpoints = 200;
var hitpoints = 200;
//var defeated : GameObject;

function Start () {
Max_Hitpoints = hitpoints;
}

function Update () {
if (hitpoints <= 0)
{
Destroy (gameObject);
}
}

function OnCollisionEnter (collision : Collision)
{
if(collision.transform.name == ("Laser(Clone)"))
{
hitpoints = hitpoints - 5;
}
}