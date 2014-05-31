using UnityEngine;
using System.Collections;
using System;

public class SwitchLevels : MonoBehaviour {
	public int index;
	private int where;
	private bool go;

	void Start(){
		init();
	}

	void init()
	{
		go=false;
		int number; 
		Debug.Log(gameObject);
		bool result = Int32.TryParse(gameObject.tag[0]+"", out number);
		index=1;
		if (!result)
		{
			Debug.Log("nu a mers conversia tagului");
		}
		else
			index=number;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (!go)
		{
			go=true;
			Debug.Log (other.gameObject);
			Debug.Log(gameObject.tag);
			Debug.Log("from level "+index);
			if (gameObject.tag.Contains("Up"))
				where=index-1;
			else
			{
				if (gameObject.tag.Contains("Down"))
					where=index+1;
			}
			Debug.Log("to level "+where);
			if (where>0 && where<10)
				Application.LoadLevel(where);
			else
				Application.LoadLevel(0);
		}
	}
}
