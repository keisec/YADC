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
		moveHorizontal=0;
		moveVertical=0;
		if(Input.GetKey("a"))moveHorizontal-=1;
		if(Input.GetKey("d"))moveHorizontal+=1;
		if(Input.GetKey("w"))moveVertical+=1;
		if(Input.GetKey("s"))moveVertical-=1;
		//moveHorizontal=Input.GetAxis("Horizontal");
		//moveVertical=Input.GetAxis("Vertical");
		movementVector.Set(moveHorizontal,moveVertical);
		//movementVector.Scale(walkingSpeed);
		rigidbody2D.velocity=movementVector*walkingSpeed;

		CheckMouseClick();
	}
	public float fireRate;
	public GameObject bulletObject;
	private float nextFire=0;
	public float bulletSpeed;
	private Vector3 mouse_pos;
	private Vector3 object_pos;
	private float angle;
	void CheckMouseClick(){
		mouse_pos = Input.mousePosition;
		mouse_pos.z = 0.0f; 
		object_pos = Camera.main.WorldToScreenPoint(transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		Vector3 rotationVector = new Vector3 (0, 0, angle);
		transform.rotation = Quaternion.Euler(rotationVector);
		if(Input.GetMouseButton(0)&&Time.time>nextFire){
			nextFire=Time.time+fireRate;
			GameObject bullet = (GameObject)Instantiate(bulletObject, transform.position+Vector3.Normalize(mouse_pos), transform.rotation);
			//bullet.transform.rotation.SetFromToRotation(transform.position,mouse_pos);

			//bullet.rigidbody2D.velocity.Set(Mathf.Cos(angle)*bulletSpeed,Mathf.Sin(angle)*bulletSpeed);
			bullet.rigidbody2D.AddForce(bullet.transform.right*100*bulletSpeed);
			//bullet.rigidbody2D.velocity.Set(10,10);
			//bullet.rigidbody2D.AddForce(Vector2(Mathf.Cos(angle),Mathf.Sin(angle))*bulletSpeed);
		}
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
  