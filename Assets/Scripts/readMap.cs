using UnityEngine;
using System.Collections;
using System.IO;

public class readMap : MonoBehaviour 
{
	public int[,] map;


	void Start () 
	{
		init();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void init()
	{
		/*
		map = new int[45, 35];

		StreamReader reader = new StreamReader("Assets\\Resources\\map" + whichMap + ".txt");
		string text;
		text = reader.ReadLine();
		int j = 0;
		int i;
		while (text != null) {
			string[] tokens = text.Split(',');
			for (i = 0; i < tokens.Length; i++) {
				map[j, i] = int.Parse(tokens[i]);
			}
			j++;
			text = reader.ReadLine();
			
		}*/
	}
}
