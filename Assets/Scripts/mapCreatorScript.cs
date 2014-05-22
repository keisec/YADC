using UnityEngine;
using System.Collections;
using System.IO;

public class mapCreatorScript : MonoBehaviour {
    public GameObject wall;
    public GameObject tile;
    public GameObject door1;
    public GameObject door2;
    //public GameObject player;
    public GameObject stairh;
    public GameObject stairv;
    public  GameObject lava;
    public  GameObject water;
    public  GameObject hole;
    public  GameObject fog;
    public  GameObject crossroads;
    public  GameObject teleport;
    public  GameObject safe;
    public  GameObject astro;
    private  int whichMap;

    public  int[,] map1;
    public  ArrayList mapComponentsList = new ArrayList();
    public  void init(int index) {
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
    public  void destroyMap() {
        GameObject go;
        while (mapComponentsList.Count > 0) {
            go = (GameObject)mapComponentsList[0];
            Destroy(go);
            mapComponentsList.RemoveAt(0);
        }
    }
    public  void generate() {
        //init(1);
        Vector2 position = new Vector2();
        Quaternion rotation = new Quaternion();
        for (int i = 0; i < map1.GetLength(0); i++) {
            for (int j = 0; j < map1.GetLength(1); j++) {
                position.Set(0.5f + j, 0.5f - i);
                switch (map1[i, j]) {
                    case 0: Network.Instantiate(wall, position, rotation,1);
                        break;
                    case 1: Network.Instantiate(tile, position, rotation, 1);
                        break;
                    case 2: if (map1[i - 1, j] == 0 && map1[i + 1, j] == 0)
                            Network.Instantiate(door2, position, rotation, 1);
                        if (map1[i, j - 1] == 0 && map1[i, j + 1] == 0)
                            Network.Instantiate(door1, position, rotation, 1);
                        break;
                    case 3: Network.Instantiate(water, position, rotation, 1);
                        break;
                    case 4: Network.Instantiate(crossroads, position, rotation, 1);
                        break;
                    case 5: Network.Instantiate(lava, position, rotation, 1);
                        break;
                    case 6: Network.Instantiate(hole, position, rotation, 1);
                        break;
                    case 7: Network.Instantiate(fog, position, rotation, 1);
                        break;
                    case 8: Network.Instantiate(safe, position, rotation, 1);
                        break;
                    case 9: Network.Instantiate(teleport, position, rotation, 1);
                        break;
                    case 12:
                        if (map1[i - 1, j] == 0 || map1[i + 1, j] == 0) {
                            astro = Network.Instantiate(stairv, position, rotation,1) as GameObject;

                        } else
                            if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0)
                                astro = Network.Instantiate(stairh, position, rotation,1) as GameObject;
                        astro.gameObject.tag = "Down";

                        break;
                    /*case 21: player.transform.position.Set(position[0], position[1], 1);
                        if (map1[i - 1, j] == 0 || map1[i + 1, j] == 0)
                            astro = Instantiate(stairv, position, rotation) as GameObject;
                        else
                            if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0)
                                astro = Instantiate(stairh, position, rotation) as GameObject;
                        astro.gameObject.tag = "Up";
                        break;*/
                }
            }
        }
    }

}
