using UnityEngine;
using System.Collections;
using System.IO;

public class mapCreatorScript : MonoBehaviour {
	public GameObject wall;
	public GameObject tile;
<<<<<<< HEAD
	public GameObject door1;
	public GameObject door2;
	public GameObject player;
	public GameObject stairh;
	public GameObject stairv;
	public GameObject lava;
	public GameObject water;
	public GameObject hole;
	public GameObject fog;
	public GameObject crossroads;
	public GameObject teleport;
	public GameObject safe;
	public GameObject astro;
	private int whichMap;

	public int[,] map1;

	public void init(int index)
	{
		whichMap = index;
		map1=new int[45,35];

		//FileStream theSourceFile = new FileStream(@"map"+whichMap+".txt", 
		//                                          FileMode.OpenOrCreate, 
		//                                          FileAccess.ReadWrite, 
		//                                          FileShare.None);
		//FileInfo theSourceFile = new FileInfo ("Assets\\Resources\\map" +whichMap+
		//	".txt");
		StreamReader reader = new StreamReader("Assets\\Resources\\map" +whichMap+".txt");
		string text;
		text = reader.ReadLine();
		int j=0;
		int i;
		while (text != null)
		{
			string[] tokens = text.Split(',');
			for( i=0; i<tokens.Length; i++ ) 
			{
				map1[j,i]=int.Parse(tokens[i]);
			}
			j++;
			text = reader.ReadLine();
			
		} 
	}
	
	
	public void Start () 
	{
		init(1);
		Vector2 position=new Vector2();
		Quaternion rotation=new Quaternion();
		for(int i=0;i<map1.GetLength(0);i++)
		{
			for(int j=0;j<map1.GetLength(1);j++)
			{
				position.Set(0.5f+j,0.5f-i);
				switch(map1[i,j])
				{
				case 0:Instantiate(wall,position,rotation);
					break;
				case 1:Instantiate(tile,position,rotation);
					break;
				case 2:if (map1[i-1,j]==0 && map1[i+1,j]==0)
						Instantiate(door2,position,rotation);
					if (map1[i,j-1]==0 && map1[i,j+1]==0)
						Instantiate(door1,position,rotation);
					break;
				case 3:Instantiate(water,position,rotation);
					break;
				case 4:Instantiate(crossroads,position,rotation);
					break;
				case 5:Instantiate(lava,position,rotation);
					break;
				case 6:Instantiate(hole,position,rotation);
					break;
				case 7:Instantiate(fog,position,rotation);
					break;
				case 8:Instantiate(safe,position,rotation);
					break;
				case 9:Instantiate(teleport,position,rotation);
					break;
				case 12:
					if (map1[i-1,j]==0 || map1[i+1,j]==0)
					{
						 astro=Instantiate(stairv,position,rotation)as GameObject;

					}
					else
						if (map1[i,j-1]==0 || map1[i,j+1]==0)
							astro =Instantiate(stairh,position,rotation)as GameObject;
					astro.gameObject.tag="Down";

					break;
				case 21:player.transform.position.Set (position[0],position[1],1);
					if (map1[i-1,j]==0 || map1[i+1,j]==0)
						astro =Instantiate(stairv,position,rotation)as GameObject;
					else
						if (map1[i,j-1]==0 || map1[i,j+1]==0)
							astro =Instantiate(stairh,position,rotation)as GameObject;
					astro.gameObject.tag="Up";
					break;
=======
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
>>>>>>> e2c90de440a9643154a9f16a0b317f3ca68c1adf
				}
			}
		}
	}

}
