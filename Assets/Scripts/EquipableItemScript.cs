using UnityEngine;
using System.Collections;
public enum ItemType{Armour,OneHandedMeleeWeapon,Shield,TwoHandedMeleeWeapon,RangedWeapon,Quiver}

public class EquipableItemScript : GenericItemScript {
	public ItemType type;
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void use(){
	}
}
