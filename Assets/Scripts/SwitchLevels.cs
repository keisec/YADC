using UnityEngine;
using System.Collections;

public class SwitchLevels : MonoBehaviour {
	int index;

	void init(int who)
	{
		index=who;
		if (gameObject.tag=="Down")
			index++;
		else
			if(gameObject.tag=="Up")
				index--;
	}
	// Use this for initialization
	void Start () {
		init(0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("to level "+index);
		Application.LoadLevel(index);
	}
}
