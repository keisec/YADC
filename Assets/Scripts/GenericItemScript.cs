using UnityEngine;
using System.Collections;

public class GenericItemScript : MonoBehaviour {
	public string itemName;
	public string itemDescription;
	public Texture itemTexture;
	public bool toDestroy=false;
	private float timeDropped;
	public bool dropped=true;
	private const float MAX_TIME_DROPPED=300;
	// Use this for initialization
	void Start () {
		//GameObject go=GameObject.CreatePrimitive(PrimitiveType.Cube);
		//go.renderer.material.mainTexture = Resources.LoadAssetAtPath<Texture> ("Assets/Resources/Textures/wall");
		this.renderer.material.mainTexture = itemTexture;
		timeDropped = 0;
		//Debug.Log ("1");
	}
	void OnMouseDown(){
		//Debug.Log ("1");
		use ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dropped) {
		} else {
			timeDropped+=Time.deltaTime;
			if(timeDropped>=MAX_TIME_DROPPED)Destroy(gameObject);
		}
	}
	public virtual void use(){
		if (dropped) {
			GameObject inv = GameObject.FindGameObjectWithTag ("Inventar");
			inv.GetComponent<InteractionWithInventoryScript> ().AddItem (this.gameObject);
			Destroy (this.gameObject);
		}
	}

	public void drop(Vector3 position){
		transform.position = position;
		gameObject.SetActive (true);
		dropped = true;
		timeDropped = 0;
	}

	public static GameObject create(Vector3 position,GameObject item,Texture t){
		Quaternion rotation=new Quaternion();
		GameObject gi = Network.Instantiate (item,position,rotation,0) as GameObject;
		gi.GetComponent<GenericItemScript>().itemTexture = t;
		return gi;
	}
}
