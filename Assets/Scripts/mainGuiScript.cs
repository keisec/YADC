using UnityEngine;
using System.Collections;
using System.IO;
public class mainGuiScript : MonoBehaviour {
    public string connectionIP = "localhost";
    public int portNumber = 8632;
    private bool connected = false;
    public float hpbarDisplay; //current progress
    public float mbbarDisplay;
    public Vector2 poshb = new Vector2(20, 40);
    public Vector2 posmb = new Vector2(20, 60);
    private Vector2 size;
    public float maxHealth = 100;
    public float curHealth = 100;
    public float maxMana = 100;
    public float curMana = 100;
    public float barHeight = 9;
    public float healthBarlenght;
    public float dimbarDinscreen = 2;
    private GUIStyle currentStyleempty = null;
    private GUIStyle hpcurrentStyle = null;
    private GUIStyle mncurrentStyle = null;
    public GameObject PlayerPrefab;
    public Transform spawnPosition;
    //public GameObject mapCreator;
    private GameObject thisPlayer;
    public cameraMovementScript cameraScript;
    public void CreatePlayer() {
        connected = true;
        thisPlayer = (GameObject)Network.Instantiate(PlayerPrefab,
        spawnPosition.position, spawnPosition.rotation, 1);
        //thisPlayer.camera.enabled = true;
        //cameraMovementScript.Follow(thisPlayer);
        cameraScript.Follow(thisPlayer);
    }
    private void OnConnectedToServer() {
        //A client has just connected
        Debug.Log("Connected To Server");
        CreatePlayer();
        //connected = true;
        
        //Application.LoadLevel("mainScene");
    }
    private void OnServerInitialized() {
        //The server has initialized
        
        init(1);
        generate();
        
        CreatePlayer();
        //connected = true;
        //Application.LoadLevel("mainScene");
    }
    private void OnDisconnectedFromServer() {
        //The connection has been lost or disconnected
        connected = false;
    }
    void OnFailedToConnect(NetworkConnectionError error) {
        Debug.Log("Could not connect to server: " + error);
    }
    void OnDisconnectedFromServer(NetworkDisconnection info) {
        if (Network.isServer)
            Debug.Log("Local server connection disconnected");
        else
            if (info == NetworkDisconnection.LostConnection)
                Debug.Log("Lost connection to the server");
            else
                Debug.Log("Successfully diconnected from the server");
    }
    private void OnGUI() {
        if (!connected) {
            connectionIP = GUILayout.TextField(connectionIP);
            int.TryParse(GUILayout.TextField(portNumber.ToString()), out portNumber);
            if (GUILayout.Button("Connect")) {
                Debug.Log("Attepting to connect");
                Network.Connect(connectionIP, portNumber);
            }
            if (GUILayout.Button("Host"))
                Network.InitializeServer(4, portNumber, false);
        } else {
            GUILayout.Label("Connections: " + Network.connections.Length.ToString());
            if (GUILayout.Button("Disconnect")) {
                Destroy(thisPlayer);
                destroyMap();
                Network.Disconnect();
            }
            InitStyles();
            GUI.BeginGroup(new Rect(poshb.x, poshb.y, healthBarlenght, 20));
            GUI.Box(new Rect(0, 0, healthBarlenght, barHeight), "", currentStyleempty);

            //draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, healthBarlenght * hpbarDisplay, 20));
            GUI.Box(new Rect(0, 0, healthBarlenght, barHeight), "", hpcurrentStyle);
            GUI.EndGroup();
            GUI.EndGroup();

            GUI.BeginGroup(new Rect(posmb.x, posmb.y, healthBarlenght, 20));
            GUI.Box(new Rect(0, 0, healthBarlenght, barHeight), "", currentStyleempty);

            //draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, healthBarlenght * mbbarDisplay, 20));
            GUI.Box(new Rect(0, 0, healthBarlenght, barHeight), "", mncurrentStyle);
            GUI.EndGroup();
            GUI.EndGroup();
        }
    }
    public GameObject wall;
    public GameObject tile;
    public GameObject door1;
    public GameObject door2;
    //public GameObject player;
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
    public ArrayList mapComponentsList = new ArrayList();
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
    public void destroyMap() {
        /*Debug.Log("Destroying map");
        GameObject go;
        while (mapComponentsList.Count > 0) {
            go = (GameObject)mapComponentsList[0];
            Debug.Log("Destroy " + go.transform);
            Destroy(go);
            mapComponentsList.RemoveAt(0);
        }*/
        foreach (GameObject go in mapComponentsList) {
            Destroy(go);
        }
        mapComponentsList.Clear();
    }
    public void generate() {
        //init(1);
        Vector2 position = new Vector2();
        Quaternion rotation = new Quaternion();
        for (int i = 0; i < map1.GetLength(0); i++) {
            for (int j = 0; j < map1.GetLength(1); j++) {
                position.Set(0.5f + j, 0.5f - i);
                switch (map1[i, j]) {
                    case 0: mapComponentsList.Add(Network.Instantiate(wall, position, rotation, 1));
                        break;
                    case 1: mapComponentsList.Add(Network.Instantiate(tile, position, rotation, 1));
                        break;
                    case 2: if (map1[i - 1, j] == 0 && map1[i + 1, j] == 0)
                            mapComponentsList.Add(Network.Instantiate(door2, position, rotation, 1));
                        if (map1[i, j - 1] == 0 && map1[i, j + 1] == 0)
                            mapComponentsList.Add(Network.Instantiate(door1, position, rotation, 1));
                        break;
                    case 3: mapComponentsList.Add(Network.Instantiate(water, position, rotation, 1));
                        break;
                    case 4: mapComponentsList.Add(Network.Instantiate(crossroads, position, rotation, 1));
                        break;
                    case 5: mapComponentsList.Add(Network.Instantiate(lava, position, rotation, 1));
                        break;
                    case 6: mapComponentsList.Add(Network.Instantiate(hole, position, rotation, 1));
                        break;
                    case 7: mapComponentsList.Add(Network.Instantiate(fog, position, rotation, 1));
                        break;
                    case 8: mapComponentsList.Add(Network.Instantiate(safe, position, rotation, 1));
                        break;
                    case 9: mapComponentsList.Add(Network.Instantiate(teleport, position, rotation, 1));
                        break;
                    case 12:
                        if (map1[i - 1, j] == 0 || map1[i + 1, j] == 0) {
                            //astro = mapComponentsList.Add(Network.Instantiate(stairv, position, rotation, 1)) as GameObject;

                        } else
                            if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0) {

                            }
                                //astro = mapComponentsList.Add(Network.Instantiate(stairh, position, rotation, 1)) as GameObject;
                        //astro.gameObject.tag = "Down";

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
    void Start() {
        Network.sendRate = 30;
        healthBarlenght = Screen.width / dimbarDinscreen;

    }

    void Update() {
        //for this example, the bar display is linked to the current time,
        //however you would set this value based on your desired display
        //eg, the loading progress, the player's health, or whatever.
        AdjustcurHealth(0);
        AdjustcurMana(0);
        //   hpbarDisplay = MyControlScript.staticHealth;
    }
    public void AdjustcurHealth(int adjhp) {
        curHealth += adjhp;
        if (curHealth < 0)
            curHealth = 0;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        if (maxHealth < 1)
            maxHealth = 1;
        hpbarDisplay = (curHealth / (float)maxHealth);
        healthBarlenght = Screen.width / dimbarDinscreen;
    }

    public void AdjustcurMana(int adjmana) {
        curMana += adjmana;
        if (curMana < 0)
            curMana = 0;
        if (curMana > maxMana)
            curMana = maxMana;
        if (maxMana < 1)
            maxMana = 1;
        mbbarDisplay = (curMana / (float)maxMana);
        healthBarlenght = Screen.width / dimbarDinscreen;
    }
    private void InitStyles() {
        if (hpcurrentStyle == null) {
            hpcurrentStyle = new GUIStyle(GUI.skin.box);
            hpcurrentStyle.normal.background = MakeTex(2, 2, new Color(1, 0, 0, 1));
        }
        if (currentStyleempty == null) {
            currentStyleempty = new GUIStyle(GUI.skin.box);
            currentStyleempty.normal.background = MakeTex(2, 2, new Color(0, 0, 0, 1));
        }
        if (mncurrentStyle == null) {
            mncurrentStyle = new GUIStyle(GUI.skin.box);
            mncurrentStyle.normal.background = MakeTex(2, 2, new Color(0, 0, 1, 1));
        }
    }



    private Texture2D MakeTex(int width, int height, Color col) {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i) {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
