using UnityEngine;
using System.Collections;

public class ChestInteractionScript : MonoBehaviour {
	public ArrayList items;
	void Start(){
		items = new ArrayList ();
	}
	public void populate(ArrayList it){
		items = it.Clone();
	}
}
