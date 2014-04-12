using UnityEngine;
using System.Collections;
using System.IO;

public class mapCreatorScript : MonoBehaviour {
	public GameObject wall;
	public GameObject tile;
	public GameObject door1;
	public GameObject door2;
	public GameObject player;
	public GameObject stair1;
	public GameObject stair2;
	private int whichMap;

	private int[,] map1;

	public void init(int index)
	{
		whichMap = index;
		map1=new int[45,35];

		FileInfo theSourceFile = new FileInfo ("Assets\\Resources\\map" +whichMap+
			".txt");
		StreamReader reader = theSourceFile.OpenText();
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
				if(map1[i,j]==1)
				{
					Instantiate(tile,position,rotation);
				}
				else if (map1[i,j]==0)
					Instantiate(wall,position,rotation);
				else if (map1[i,j]==21 || map1[i,j]==12)
				{
					if (map1[i,j]==21)
						player.transform.position.Set (position[0],position[1],1);

					else
					{
						//Application.LoadLevel(Level);
					}
					if (map1[i-1,j]==0 || map1[i+1,j]==0)
						Instantiate(stair2,position,rotation);
					if (map1[i,j-1]==0 || map1[i,j+1]==0)
						Instantiate(stair1,position,rotation);
				}

				else if(map1[i,j]==2)
				{
					if (map1[i-1,j]==0 && map1[i+1,j]==0)
						Instantiate(door2,position,rotation);
					if (map1[i,j-1]==0 && map1[i,j+1]==0)
						Instantiate(door1,position,rotation);
				}
			}
		}
	}

}
