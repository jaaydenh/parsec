using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {

	//public GameObject player;

	public Boundary boundary;
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	public float offset;
	public float forwardSpeed;

	private float targetManeuver;
	private Rigidbody rigidBody;

	private float xpos;

	void Start ()
	{
		rigidBody = GetComponent <Rigidbody> ();
		//currentSpeed = GetComponent<Rigidbody>().velocity.z;
		StartCoroutine(Evade());
		xpos = 25;
	}
	
	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			targetManeuver = Random.Range (-10, 10) * -Mathf.Sign (transform.position.z);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			xpos = Mathf.MoveTowards (xpos, 5, forwardSpeed * Time.deltaTime);
			rigidBody.position = new Vector3(xpos, 0, Mathf.Lerp(transform.position.z, player.GetComponent<Rigidbody> ().position.z + offset, Time.deltaTime * smoothing));
		}
		//float xpos = Mathf.Lerp(transform.position.x, player.transform.position.x, forwardSpeed);
		//transform.position = new Vector3 (xpos, 0, transform.position.z); 

		//float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody>().velocity.x, 10, smoothing * Time.deltaTime);
		//GetComponent<Rigidbody>().velocity = new Vector3 (newManeuver, 0.0f, forwardSpeed);

		//GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f, 0.0f, player.GetComponent<Rigidbody> ().position.z);
//		float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody>().velocity.z, targetManeuver, smoothing * Time.deltaTime);
//		GetComponent<Rigidbody>().velocity = new Vector3 (0.0f, 0.0f, -10);
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
//		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody>().velocity.z * -tilt);
	}
}
