using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerScript : MonoBehaviour {


	private static List<GameObject> _inventory=new List<GameObject>();
	public static List<GameObject> Inventory{
		get {return _inventory;}
	}

	public float walkingSpeed;
	public float maximumHP;
	private static GameObject instance;
	private float currentHP;
	private float moveVertical;
	private float moveHorizontal;
	private Vector2 movementVector=new Vector2();

	public float steppingSpeed;
	private bool steppedLastTime;
	private float nextStepTime=0;
	private int currentStep=0;
    public float shotDamage = 4;
	public Texture textureStanding,textureWalking1,textureWalking2;
	
	void Start()
	{
		mainGuiScript.AdjustcurHealth(currentHP, maximumHP);
		PlayerPrefs.SetFloat("PlayX",instance.transform.position.x);
		PlayerPrefs.SetFloat("PlayY",instance.transform.position.y);
	}
//
//	void FixedUpdate(){
//		moveHorizontal=0;
//		moveVertical=0;
//		if(Input.GetKey("a"))moveHorizontal-=1;
//		if(Input.GetKey("d"))moveHorizontal+=1;
//		if(Input.GetKey("w"))moveVertical+=1;
//		if(Input.GetKey("s"))moveVertical-=1;
//		//PlayerPrefs.SetFloat("PozH",moveHorizontal);
//		//PlayerPrefs.SetFloat("PozV",moveVertical);
//
//		if(moveVertical!=0||moveHorizontal!=0){
//			if(steppedLastTime&&Time.time>nextStepTime){
//				nextStepTime=Time.time+steppingSpeed;
//				currentStep++;
//				renderer.material.mainTexture=currentStep%2==0?textureWalking1:textureWalking2;
//			}
//			steppedLastTime=true;
//		}else{
//			steppedLastTime=false;
//			renderer.material.mainTexture=textureStanding;
//		}
//		//moveHorizontal=Input.GetAxis("Horizontal");
//		//moveVertical=Input.GetAxis("Vertical");
//		movementVector.Set(moveHorizontal,moveVertical);
//		//movementVector.Scale(walkingSpeed);
//		rigidbody2D.velocity=movementVector*walkingSpeed;
//>>>>>>> origin/Alina1

	void FixedUpdate(){

        if (networkView.isMine) {
            moveHorizontal = 0;
            moveVertical = 0;
		
            if (Input.GetKey("a")) moveHorizontal -= 1;
            if (Input.GetKey("d")) moveHorizontal += 1;
            if (Input.GetKey("w")) moveVertical += 1;
            if (Input.GetKey("s")) moveVertical -= 1;

//<<<<<<< HEAD
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
            //rigidbody2D.AddForce(movementVector * walkingSpeed*5);
            CheckMouseClick();
        }
	}
//=======
//		CheckMouseClick();
//	}

	void Awake() 
	{
		Debug.Log(instance);
		if(instance == null)
		{
			instance = gameObject;
			DontDestroyOnLoad (gameObject);
		}
		else
			DestroyImmediate(gameObject);

	}

	void OnLevelWasLoaded(int level) 
	{
		if (level == 0)
			Destroy(this.gameObject);
		
	}

	private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		//int health = 0;
		Vector3 poz=Vector3.zero;
		if (stream.isWriting) {
			poz=transform.position;
			stream.Serialize(ref poz);
			Debug.Log("Poz WRITE = "+poz.ToString());
		} else {
			stream.Serialize(ref poz);
			transform.position=poz;
			Debug.Log ("Poz READ = "+poz.ToString());
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
		if(Time.time>nextFire&&Input.GetMouseButton(0)){
            mouse_pos = Input.mousePosition;
            mouse_pos.z = 0.0f;
            object_pos = camera.WorldToScreenPoint(transform.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

            qAngle = Quaternion.Euler(new Vector3(0, 0, angle));
			nextFire=Time.time+fireRate;
			GameObject bullet = (GameObject)Network.Instantiate(bulletObject, transform.position+Vector3.Normalize(mouse_pos)/2, qAngle,0);
            /*foreach (GameObject g in mainGuiScript.playerList) {
                Physics2D.IgnoreCollision(g.collider2D, bullet.collider2D,true);
                Physics2D.IgnoreCollision(bullet.collider2D, g.collider2D, true);
            }*/
            //Vector2 vel=bullet.transform.right*100*bulletSpeed;
            bullet.GetComponent<bulletScript>().damage = shotDamage;
            bullet.rigidbody2D.AddForce(bullet.transform.right*100*bulletSpeed*bullet.rigidbody2D.mass);
            //bullet.rigidbody2D.velocity.Set(vel.x, vel.y);
		}
	}
    private Vector2 aux = new Vector2();
    void OnCollisionEnter2D(Collision2D other) {
        if (networkView.isMine&&other.gameObject.tag == "Monster") {
            try {
                aux = (other.transform.position - transform.position).normalized/10;
                other.gameObject.transform.position += (Vector3)aux;
                transform.position -= (Vector3)aux;
                currentHP -= other.gameObject.GetComponent<monsterScript>().hitDamage;
                mainGuiScript.AdjustcurHealth(currentHP, maximumHP);
                if (currentHP <= 0) {
                    Network.RemoveRPCs(networkView.viewID);
                    Network.Destroy(gameObject);
                }
            } catch (UnityException e) {
                Debug.Log("Collision with bullet error = " + e.Message);
            }
        }
    }

}
