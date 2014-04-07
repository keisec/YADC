using UnityEngine;
using System.Collections;

public class mapCreatorScript : MonoBehaviour {
	public GameObject wall;
	private int [,] mapExample=new int[,] {
		{1,1,1,1,1,1,1,0,0,0,1,1,1,1,1},
		{1,0,0,0,0,0,1,0,0,0,1,0,0,0,1},
		{0,0,0,0,0,0,1,0,0,0,1,0,0,0,1},
		{1,1,1,0,1,1,1,0,0,1,1,0,0,0,1},
		{0,0,1,0,1,0,0,0,1,1,0,0,0,0,1},
		{0,0,1,0,1,1,1,1,1,0,0,0,0,0,1},
		{0,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
		{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1}};
	void Start () {
		Vector2 position=new Vector2();
		Quaternion rotation=new Quaternion();
		for(int i=0;i<mapExample.GetLength(0);i++){
			for(int j=0;j<mapExample.GetLength(1);j++){
				if(mapExample[i,j]==1){
					position.Set(0.5f+j,0.5f-i);
					Instantiate(wall,position,rotation);
				}
			}
		}
	}
}
