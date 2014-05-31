using UnityEngine;
using System.Collections;
using System.IO;

public class mapCreatorScript : MonoBehaviour {
    public GameObject wall;
    public GameObject tile;
    public GameObject door1;
    public GameObject door2;
    private GameObject player;

    public GameObject stairh;
    public GameObject stairv;
    public GameObject lava;
    public GameObject water;
    public GameObject hole;
    public GameObject fog;
    public GameObject crossroads;
    public GameObject teleport;
    public GameObject safe;
    
    public int whichMap;

	private GameObject[,] objMap;
	private int sight=4;
	private int si,ti,sj,tj;

    public int[,] map1;

	private int playerX,playerY;
	private int pozV,pozH;

    public void init() {
		player=GameObject.FindWithTag("Player");
        map1 = new int[45, 35];
		objMap=new GameObject[45,35];
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

	void Update()
	{
		int i,j,diff;
		//bool doit=false;
		int x=(int)Mathf.Floor(player.transform.position.x-0.5f);
		int y=(int)Mathf.Abs(Mathf.Floor(player.transform.position.y+0.5f))+1;
		//Debug.Log("playerxy: "+x+" , "+y);
		//Debug.Log("player: "+playerX+" , "+playerX);
			if (playerX>x)
			{
				diff=playerX-(int)x;
				Debug.Log("player: "+y+" , "+x);
				playerX=(int)x;
				sj-=diff;
				tj-=diff;
				Debug.Log("cols: " + sj+" , "+tj);
				Debug.Log("discovered: col" + sj);
			if (sj>=0){
				if (diff==1)
				{
					for (i=si;i<=ti;i++)
						if (i>=0 && i<=44 && !objMap[i,sj].activeSelf)
							objMap[i,sj].SetActive(true);
				}
				else
				{
					for (i=si;i<=ti;i++)
						for (j=sj;j<=tj;j++)
							if (i>=0 && i<=44 && j>=0 && j<=34 && !objMap[i,j].activeSelf)
								objMap[i,j].SetActive(true);
				}
			}
			}
		if (playerX<x)
			{
			diff=(int)x-playerX;
				playerX=(int)x;
				Debug.Log("player: "+y+" , "+x);
				sj+=diff;
				tj+=diff;
				Debug.Log("cols: " + sj+" , "+tj);
				Debug.Log("discovered: col" + tj);
			if (tj<=34){
				if (diff==1)
				{
					for (i=si;i<=ti;i++)
						if (i>=0 && i<=44 && !objMap[i,tj].activeSelf)
							objMap[i,tj].SetActive(true);
				}
				else
				{
				for (i=si;i<=ti;i++)
					for (j=sj;j<=tj;j++)
						if (i>=0 && i<=44 && j>=0 && j<=34 && !objMap[i,j].activeSelf)
							objMap[i,j].SetActive(true);
				}
			}
			}
		if (playerY>y)
			{
				diff=playerY-(int)y;
				playerY=(int)y;
				Debug.Log("player: "+y+" , "+x);
				si-=diff;
				ti-=diff;
				Debug.Log("lines: " + si+" , "+ti);
				Debug.Log("discovered: line" + si);
			if (si>=0){
				if (diff==1)
				{
					for (i=sj;i<=tj;i++)
						if (i>=0 && i<=34 && !objMap[si,i].activeSelf)
							objMap[si,i].SetActive(true);
				}
				else
				{
					for (i=si;i<=ti;i++)
						for (j=sj;j<=tj;j++)
							if (i>=0 && i<=44 && j>=0 && j<=34 && !objMap[i,j].activeSelf)
								objMap[i,j].SetActive(true);
				}
			}
			}
		if (playerY<y)
			{
				diff=(int)y-playerY;
				playerY=(int)y;
				Debug.Log("player: "+y+" , "+x);
				si+=diff;
				ti+=diff;
				Debug.Log("lines: " + si+" , "+ti);
				Debug.Log("discovered: line" + ti);
			if (ti<=44){
				if (diff==1)
				{
					for (i=sj;i<=tj;i++)
						if (i>=0 && i<=34 && !objMap[ti,i].activeSelf)
							objMap[ti,i].SetActive(true);
				}
				else
				{
					for (i=si;i<=ti;i++)
						for (j=sj;j<=tj;j++)
							if (i>=0 && i<=44 && j>=0 && j<=34 && !objMap[i,j].activeSelf)
								objMap[i,j].SetActive(true);
				}
			}
			}


	}

    public void Start() {
        init();
		int i,j;
        Vector2 position = new Vector2();
        Quaternion rotation = new Quaternion();
        for ( i = 0; i < map1.GetLength(0); i++) {
            for ( j = 0; j < map1.GetLength(1); j++) {
                position.Set(0.5f + j, 0.5f - i);
                switch (map1[i, j]) {
					case 0: 
						objMap[i,j]=Instantiate(wall, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 1: 
						objMap[i,j]=Instantiate(tile, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 2:
						if (i>0 && i<map1.GetLength(0)-1 && map1[i - 1, j] == 0 && map1[i + 1, j] == 0)
							objMap[i,j]=Instantiate(door2, position, rotation)as GameObject;
                        if (j>0 && j<map1.GetLength(1)-1 && map1[i, j - 1] == 0 && map1[i, j + 1] == 0)
							objMap[i,j]=Instantiate(door1, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 3: 
						objMap[i,j] =Instantiate(water, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 4: 
						objMap[i,j]=Instantiate(crossroads, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 5: 
						objMap[i,j]=Instantiate(lava, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 6: 
						objMap[i,j]=Instantiate(hole, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 7: 
						objMap[i,j]=Instantiate(fog, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 8: 
						objMap[i,j]=Instantiate(safe, position, rotation)as GameObject;
						objMap[i,j].SetActive(false);
                        break;
                    case 9: 
						objMap[i,j]=Instantiate(teleport, position, rotation)as GameObject;
						objMap[i,j].tag=whichMap+"";
						objMap[i,j].AddComponent<TeleportScript>();
						objMap[i,j].SetActive(false);
                        break;
                    case 12:
                        if (map1[i - 1, j] == 0 || map1[i + 1, j] == 0) 
							objMap[i,j] = Instantiate(stairv, position, rotation) as GameObject;

                         else
                            if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0)
								objMap[i,j] = Instantiate(stairh, position, rotation) as GameObject;
						objMap[i,j].gameObject.tag = whichMap+"Down";
						objMap[i,j].AddComponent<SwitchLevels>();
						objMap[i,j].SetActive(false);
                        break;
                    case 21: 
                        if (map1[i - 1, j] == 0 || map1[i + 1, j] == 0)
							objMap[i,j] = Instantiate(stairv, position, rotation) as GameObject;
                        else
                            if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0)
								objMap[i,j]= Instantiate(stairh, position, rotation) as GameObject;
						objMap[i,j].gameObject.tag = whichMap+"Up";
						objMap[i,j].AddComponent<SwitchLevels>();
						objMap[i,j].SetActive(false);
                        break;
                }
            }
        }
		//getting player position to set surrounding tiles visible
		playerX=(int)PlayerPrefs.GetFloat("PlayX");
		playerY=(int)Mathf.Abs(PlayerPrefs.GetFloat("PlayY"))+1;
		Debug.Log("player: "+playerX+" , "+playerY);
		si=playerX-sight;
		sj=playerY-sight;
		ti=playerX+sight;
		tj=playerY+sight;
		Debug.Log("lines: "+si+" , "+ti);
		Debug.Log("lines: "+sj+" , "+tj);
		for (i=si;i<=ti;i++)
			for(j=sj;j<=tj;j++)
				if (i>=0 && i<=44 && j>=0 && j<=34 && !objMap[i,j].activeSelf)
					//if (j>0 && map1[i,j-1]==0);
					//else
						objMap[i,j].SetActive(true);

    }

}
