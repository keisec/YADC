using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
	public float walkingSpeed;
	public float maximumHP;

	private float currentHP;
	private float moveVertical;
	private float moveHorizontal;
	private Vector2 movementVector=new Vector2();

	public float steppingSpeed;
	private bool steppedLastTime;
	private float nextStepTime=0;
	private int currentStep=0;
	public Texture textureStanding,textureWalking1,textureWalking2;
	void FixedUpdate(){
        if (networkView.isMine) {
            moveHorizontal = 0;
            moveVertical = 0;
            if (Input.GetKey("a")) moveHorizontal -= 1;
            if (Input.GetKey("d")) moveHorizontal += 1;
            if (Input.GetKey("w")) moveVertical += 1;
            if (Input.GetKey("s")) moveVertical -= 1;

            if (moveVertical != 0 || moveHorizontal != 0) {
                if (steppedLastTime && Time.time > nextStepTime) {
                    nextStepTime = Time.time + steppingSpeed;
                    currentStep++;
                    renderer.material.mainTexture = currentStep % 2 == 0 ? textureWalking1 : textureWalking2;
                }
                steppedLastTime = true;
            } else {
                steppedLastTime = false;
                renderer.material.mainTexture = textureStanding;
            }
            movementVector.Set(moveHorizontal, moveVertical);
            rigidbody2D.velocity = movementVector * walkingSpeed;

            CheckMouseClick();
        }
	}
	public float fireRate;
	public GameObject bulletObject;
	private float nextFire=0;
	public float bulletSpeed;
	private Vector3 mouse_pos;
	private Vector3 object_pos;
	private float angle;
	private Quaternion qAngle;
	void CheckMouseClick(){
		mouse_pos = Input.mousePosition;
		mouse_pos.z = 0.0f; 
        object_pos = camera.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

		qAngle=Quaternion.Euler(new Vector3(0,0,angle));
		if(Input.GetMouseButton(0)&&Time.time>nextFire){
			nextFire=Time.time+fireRate;
			GameObject bullet = (GameObject)Network.Instantiate(bulletObject, transform.position+Vector3.Normalize(mouse_pos)/2, qAngle,0);
            /*foreach (GameObject g in mainGuiScript.playerList) {
                Physics2D.IgnoreCollision(g.collider2D, bullet.collider2D,true);
                Physics2D.IgnoreCollision(bullet.collider2D, g.collider2D, true);
            }*/
            //Vector2 vel=bullet.transform.right*100*bulletSpeed;
            bullet.rigidbody2D.AddForce(bullet.transform.right*100*bulletSpeed*bullet.rigidbody2D.mass);
            //bullet.rigidbody2D.velocity.Set(vel.x, vel.y);
		}
	}


}