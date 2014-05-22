using UnityEngine;
using System.Collections;
using System.IO;

public class mapCreatorScript : MonoBehaviour {
<<<<<<< HEAD
    public GameObject wall;
    public GameObject tile;
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

    public void init(int index) {
        whichMap = index;
        map1 = new int[45, 35];

        //FileStream theSourceFile = new FileStream(@"map"+whichMap+".txt", 
        //                                          FileMode.OpenOrCreate, 
        //                                          FileAccess.ReadWrite, 
        //                                          FileShare.None);
        //FileInfo theSourceFile = new FileInfo ("Assets\\Resources\\map" +whichMap+
        //	".txt");
        StreamReader reader = new StreamReader("Assets\\Resources\\map" + whichMap + ".txt");
        string text;
        text = reader.ReadLine();
        int j = 0;
        int i;
        while (text != null) {
            string[] tokens = text.Split(',');
            for (i = 0; i < tokens.Length; i++) {
                map1[j, i] = int.Parse(tokens[i]);
            }
            j++;
            text = reader.ReadLine();

        }
    }


    public void Start() {
        init(1);
        Vector2 position = new Vector2();
        Quaternion rotation = new Quaternion();
        for (int i = 0; i < map1.GetLength(0); i++) {
            for (int j = 0; j < map1.GetLength(1); j++) {
                position.Set(0.5f + j, 0.5f - i);
                switch (map1[i, j]) {
                    case 0: Instantiate(wall, position, rotation);
                        break;
                    case 1: Instantiate(tile, position, rotation);
                        break;
                    case 2: if (map1[i - 1, j] == 0 && map1[i + 1, j] == 0)
                            Instantiate(door2, position, rotation);
                        if (map1[i, j - 1] == 0 && map1[i, j + 1] == 0)
                            Instantiate(door1, position, rotation);
                        break;
                    case 3: Instantiate(water, position, rotation);
                        break;
                    case 4: Instantiate(crossroads, position, rotation);
                        break;
                    case 5: Instantiate(lava, position, rotation);
                        break;
                    case 6: Instantiate(hole, position, rotation);
                        break;
                    case 7: Instantiate(fog, position, rotation);
                        break;
                    case 8: Instantiate(safe, position, rotation);
                        break;
                    case 9: Instantiate(teleport, position, rotation);
                        break;
                    case 12:
                        if (map1[i - 1, j] == 0 || map1[i + 1, j] == 0) {
                            astro = Instantiate(stairv, position, rotation) as GameObject;

                        } else
                            if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0)
                                astro = Instantiate(stairh, position, rotation) as GameObject;
                        astro.gameObject.tag = "Down";

                        break;
                    case 21: player.transform.position.Set(position[0], position[1], 1);
                        if (map1[i - 1, j] == 0 || map1[i + 1, j] == 0)
                            astro = Instantiate(stairv, position, rotation) as GameObject;
                        else
                            if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0)
                                astro = Instantiate(stairh, position, rotation) as GameObject;
                        astro.gameObject.tag = "Up";
                        break;
                }
            }
        }
    }
=======
	public GameObject wall;
	public GameObject tile;
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
				}
			}
		}
	}
>>>>>>> b0f355bb15a2a8d2032474b175a46d132ef83efd

}
