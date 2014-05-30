using UnityEngine;
using System.Collections;

public class InteractionWithInventoryScript : MonoBehaviour {
	ArrayList items;
	public GameObject player;
	// Use this for initialization

	void Start()
	{
		items = new ArrayList ();
	}

	public void AddItem(GameObject it){
		GameObject go=Network.Instantiate((GameObject)it,((GameObject)it).transform.position,((GameObject)it).transform.rotation,0) as GameObject;
		go.SetActive(false);
		items.Add (go);
	}

	public void RemoveItem(GameObject it){
		it.GetComponent<GenericItemScript>().drop(player.transform.position);
		items.Remove (it);
	}

	public ArrayList ShowItems(){
		return items;
	}
}
