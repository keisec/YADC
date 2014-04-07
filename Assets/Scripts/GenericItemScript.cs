using UnityEngine;
using System.Collections;

public class GenericItemScript : MonoBehaviour {
	public string itemName;
	public string itemDescription;
	public Texture itemTexture;
	// Use this for initialization
	void Start () {
		itemTexture = Resources.LoadAssetAtPath<Texture> ("Assets/Resources/Textures/wall");
		GameObject go=GameObject.CreatePrimitive(PrimitiveType.Cube);
		go.renderer.material.mainTexture = Resources.LoadAssetAtPath<Texture> ("Assets/Resources/Textures/wall");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public virtual void use(){

	}
	
}
