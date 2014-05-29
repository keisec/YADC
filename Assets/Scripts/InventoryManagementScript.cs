using UnityEngine;
using System.Collections;

public class InventoryManagementScript : MonoBehaviour {

	private ArrayList items;

	InventoryManagementScript(){
		items = new ArrayList();
	}

	public void pickup(GenericItemScript it)
	{
		items.Add(it);
	}
}
