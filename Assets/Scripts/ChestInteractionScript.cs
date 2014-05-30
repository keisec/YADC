using UnityEngine;
using System.Collections;

public class ChestInteractionScript : MonoBehaviour {
	public ArrayList items;
	void Start(){
		items = new ArrayList ();
	}
	public void populate(ArrayList it){
		items = it;
	}

	public void openChest(){
		foreach (GameObject it in items) {
			it.GetComponent<GenericItemScript>().drop (gameObject.transform.position);
		}
		items.Clear ();
	}
}
