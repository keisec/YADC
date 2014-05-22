using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
	public float walkingSpeed;
	public float maximumHP;
	private float currentHP;
	private float moveVertical;
	private float moveHorizontal;
	private Vector2 movementVector=new Vector2();
	void FixedUpdate(){
		moveHorizontal=Input.GetAxis("Horizontal");
		moveVertical=Input.GetAxis("Vertical");
		movementVector.Set(moveHorizontal,moveVertical);
		//movementVector.Scale(walkingSpeed);
		rigidbody2D.velocity=movementVector*walkingSpeed;
	}


}
/*using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	[System.Serializable]
	public class Boundary{
		public float xMin,xMax,zMin,zMax;
	}
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire=0;
	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire=Time.time+fireRate;
			Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
			audio.Play();
		}

	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement=new Vector3(moveHorizontal,0.0f,moveVertical);
		rigidbody.velocity = movement*speed;
	
		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z,boundary.zMin,boundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler (0, 0, -tilt*rigidbody.velocity.x);
	}
}

 */
  