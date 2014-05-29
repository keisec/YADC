using UnityEngine;
using System.Collections;

public class InteractionWithInventoryScript : MonoBehaviour {
	ArrayList items;
	float count=0;
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

	void Update(){
		if (items.Count != 0) {
			count+=Time.deltaTime;
			if(count>1.5){
				for(int i=0;i<items.Count;i++){
					Vector2 position=new Vector2(i+(1.5f),3.5f);
					GameObject go2=(GameObject)items[i];
					go2.SetActive(true);
					go2.transform.position=position;
				}
				items.Clear();
			}
		} else {
			count =0;
		}
	}
}
