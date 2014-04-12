using UnityEngine;
using System.Collections;

public class mapCreatorScript : MonoBehaviour {
	public GameObject wall;
	public GameObject tile;
	public GameObject item;
	public Texture[] textures;
	private int [,] mapExample=new int[,] {
		{1,1,1,1,1,1,1,0,0,0,1,1,1,1,1},
		{1,2,2,2,2,2,1,0,0,0,1,2,2,2,1},
		{2,2,2,2,2,2,1,0,0,0,1,2,2,2,1},
		{1,1,1,2,1,1,1,0,0,1,1,2,2,2,1},
		{0,0,1,2,1,0,0,0,1,1,2,2,2,2,1},
		{0,0,1,2,1,1,1,1,1,2,2,2,2,2,1},
		{0,0,1,2,2,2,2,2,2,2,2,2,2,2,1},
		{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1}};
	void Start () {
		Vector3 position=new Vector3();
		Quaternion rotation=new Quaternion();
		//GameObject go=new GameObject();
		//GenericItemScript gis = go.AddComponent ("GenericItemScript") as GenericItemScript;
		//gis.itemTexture = textures [0];
		//Instantiate (go, position, rotation);
		position.Set (2.5f, 4.5f,3);
		GenericItemScript.create (position, item, textures [0]);
		position.Set (2.5f, 2.5f,3);
		GenericItemScript.create (position, item, textures [1]);

		for(int i=0;i<mapExample.GetLength(0);i++){
			for(int j=0;j<mapExample.GetLength(1);j++){
				position.Set(0.5f+j,0.5f-i,2);
				if(mapExample[i,j]==1){
					Instantiate(wall,position,rotation);
				}else if(mapExample[i,j]==2){
					Instantiate(tile,position,rotation);
				}
			}
		}
	}
}
