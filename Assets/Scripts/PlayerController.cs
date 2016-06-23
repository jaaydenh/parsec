using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	public FireAreaButton fireButton;
	public UpAreaButton upButton;
	public DownAreaButton downButton;

	private float nextFire;
	private float touchVertical;

	void Update ()
	{
		if (fireButton.CanFire () && Time.time > nextFire) {
			FireShot ();
		} else if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			FireShot ();
		}
	}

	void FireShot () {
		nextFire = Time.time + fireRate;
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource> ().Play ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal;
		float moveVertical;

		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		if (moveVertical == 0 && moveHorizontal == 0) {
			if (upButton.CanMoveUp ()) {
				moveVertical = Mathf.Lerp (touchVertical, 1.0f, 0.12f);
				touchVertical = moveVertical;
			} else if (downButton.CanMoveDown ()) {
				moveVertical = Mathf.Lerp (touchVertical, -1.0f, 0.12f);
				touchVertical = moveVertical;
			} else {
				moveVertical = Mathf.Lerp (touchVertical, 0, 0.2f);
				touchVertical = moveVertical;
			}
		}
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);

//		GetComponent<Rigidbody>().rotation = Quaternion.Euler (GetComponent<Rigidbody>().velocity.z * -tilt, 0.0f, 0.0f);
	}
}
