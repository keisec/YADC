using UnityEngine;
using System.Collections;

public class InteractionWithInventoryScript : MonoBehaviour {
	ArrayList items;
	// Use this for initialization

	InteractionWithInventoryScript()
	{
		items = new ArrayList ();
	}

	public void AddItem(GameObject it){
		GameObject go=Instantiate((GameObject)it) as GameObject;
		go.SetActive(false);
		items.Add (go);
	}
}
