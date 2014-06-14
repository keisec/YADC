using UnityEngine;
using System.Collections;
using System.IO;
public class mainGuiScript : MonoBehaviour {
    public string connectionIP = "localhost";
    public int portNumber = 8632;
	private bool connected = false;
    public static float hpbarDisplay; //current progress
    public static float mbbarDisplay;
    public Vector2 poshb = new Vector2(20, 40);
    public Vector2 posmb = new Vector2(20, 60);
    private Vector2 size;
    public static float maxHealth = 100;
    public static float curHealth = 100;
    public static float maxMana = 100;
    public static float curMana = 100;
    public float barHeight = 9;
    public static float healthBarlenght;
    public static float dimbarDinscreen = 2;
    private GUIStyle currentStyleempty = null;
    private GUIStyle hpcurrentStyle = null;
    private GUIStyle mncurrentStyle = null;
    public GameObject PlayerPrefab;
    public Transform spawnPosition;
    //public GameObject mapCreator;
    private GameObject thisPlayer;
    public static GameObject[] playerArray = null;
    public cameraMovementScript cameraScript;
    public GameObject monster;
    private ArrayList monsterList = new ArrayList();
    public static GameObject[] tileArray=null;
    /*public void CreatePlayer() {
        connected = true;
        thisPlayer = (GameObject)Network.Instantiate(PlayerPrefab,
        spawnPosition.position, spawnPosition.rotation, 0);
        cameraScript.Follow(thisPlayer);
    }*/
    private void updatePlayerArray() {
        playerArray = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("Number of players in array = " + playerArray.Length);
    }
    public static void updateTileList() {
        tileArray = GameObject.FindGameObjectsWithTag("Tile");
    }
    private void clearPlayerList() {
        foreach (GameObject g in playerArray){
            Network.RemoveRPCsInGroup(0);
            Network.Destroy(g);
        }
        
        //playerList.Clear();
    }
	
    private void OnConnectedToServer() {
        //A client has just connected
        //Debug.Log("Connected To Server");
        //CreatePlayer();
        connected = true;
        thisPlayer = (GameObject)Network.Instantiate(PlayerPrefab,
        spawnPosition.position, spawnPosition.rotation, 0);
        cameraScript.Follow(thisPlayer);
        updatePlayerArray();
    }
    private void OnServerInitialized() {
        init();
        generate();
        connected = true;
        thisPlayer = (GameObject)Network.Instantiate(PlayerPrefab,
        spawnPosition.position, spawnPosition.rotation, 0);
        cameraScript.Follow(thisPlayer);
        updatePlayerArray();
        //playerList.Add(thisPlayer);
        //CreatePlayer();
    }

    void OnFailedToConnect(NetworkConnectionError error) {
        Debug.Log("Could not connect to server: " + error);
    }
    void OnPlayerDisconnected(NetworkPlayer player) {
        Debug.Log("Clean up after player " + player);
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
        updatePlayerArray();
    }
    void OnDisconnectedFromServer(NetworkDisconnection info) {
        //Network.Destroy(thisPlayer);
       
        //destroyMapOnline();
        
        connected = false;
        if (Network.isServer) {
            Debug.Log("Local server connection disconnected");
            
        } else {
            //Network.Destroy(thisPlayer);
            
            //Network.Destroy(thisPlayer);
            if (info == NetworkDisconnection.LostConnection)
                Debug.Log("Lost connection to the server");
            else {
                Debug.Log("Successfully diconnected from the server");
                
            }
        }
        //Destroy(thisPlayer);
        foreach (GameObject g in GameObject.FindObjectsOfType(typeof(GameObject))) {
            if (g.name != "Main Light" && g.name != "GUIObject" && g.name != "Main Camera")
                Destroy(g);
        }
        updatePlayerArray();
        Application.LoadLevel("startScene");
    }
    private float nextUpdateTime=0;
    void FixedUpdate() {
        //rigidbody.AddForce(Vector3.up);
        if (Time.time > nextUpdateTime&&connected&&Network.isServer) {
            nextUpdateTime += 1.0f;
            updatePlayerArray();
        }
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
            if (GUI.Button(new Rect(Screen.width-100,0,100,20), "Disconnect")) {
                //Destroy(thisPlayer);
                //clearPlayerList();
                //destroyMap();
                if (Network.isServer) {
                    destroyMapOnline();
                    clearPlayerList();
                } else {
                    Network.Destroy(thisPlayer);
                }
                Network.Disconnect();
				Application.LoadLevel("startScene");
            }
			//if(GUI.Button(new Rect(Screen.width-100,30,100,40), "next level")){
			//	Application.LoadLevel(Application.loadedLevel);
			//}
            InitStyles();/*
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
            GUI.EndGroup();*/
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
   	private GameObject astro;
    private int whichMap=1;
    private int lastMap=0;
    private int maxMaps=10;

    public int[,] map1;
    public ArrayList mapComponentsList = new ArrayList();
    public void init() {
        map1 = new int[45, 35];
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
    public void destroyMapOnline() {
        //tileList.Clear();
        tileArray = null;
        foreach (GameObject go in mapComponentsList) {
			//Debug.Break();
            Network.RemoveRPCsInGroup(1);
			Network.Destroy(go);
        }
        mapComponentsList.Clear();
        foreach (GameObject go in monsterList) {
            Network.RemoveRPCsInGroup(0);
            Network.Destroy(go);
        }
        monsterList.Clear();
    }
	public void generate() {
		Vector2 position = new Vector2();
		Quaternion rotation = new Quaternion();
		for (int i = 0; i < map1.GetLength(0); i++) {
			for (int j = 0; j < map1.GetLength(1); j++) {
				position.Set(0.5f + j, 0.5f - i);
				switch (map1[i, j]) {
				case 0:
					mapComponentsList.Add(Network.Instantiate(wall, position, rotation, 1));
					break;
				case 1: {
					GameObject g = Network.Instantiate(tile, position, rotation, 1) as GameObject;
					mapComponentsList.Add(g);
					//tileList.Add(g);
					float x=Random.Range(1,100);
					if (x/5 == 1) {
						//monsterList.Add(Network.Instantiate(monster, position, rotation, 0));
					} 
					if(x==6){
						//add chest;
					}
				}
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
						astro = Network.Instantiate(stairv, position, rotation, 1) as GameObject;
						mapComponentsList.Add(astro);
						
					} else
					if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0) {
						astro = Network.Instantiate(stairh, position, rotation, 1) as GameObject;
						mapComponentsList.Add(astro);
					}
					if(lastMap<whichMap){
						if(map1[i-1,j]==0)
							position.Set(position.x-1,position.y);
						else
							if(map1[i+1,j]==0)
								position.Set(position.x+1,position.y);
						else
							if(map1[i,j-1]==0)
								position.Set(position.x,position.y-1);
						else
							position.Set(position.x,position.y+1);
						spawnPosition.position.Set(position.x,position.y,0);
					}
					astro.gameObject.tag = "Down";
					
					break;
				case 21: //player.transform.position.Set(position[0], position[1], 1);
					if (map1[i - 1, j] == 0 || map1[i + 1, j] == 0){
						astro = Network.Instantiate(stairv, position, rotation, 1) as GameObject;
						mapComponentsList.Add(astro);
					}
					else
					if (map1[i, j - 1] == 0 || map1[i, j + 1] == 0){
						astro = Network.Instantiate(stairh, position, rotation, 1) as GameObject;
						mapComponentsList.Add(astro);
					}
					if(lastMap>whichMap){
						if(map1[i-1,j]==0)
							position.Set(position.x-1,position.y);
						else
							if(map1[i+1,j]==0)
								position.Set(position.x+1,position.y);
						else
							if(map1[i,j-1]==0)
								position.Set(position.x,position.y-1);
						else
							position.Set(position.x,position.y+1);
						spawnPosition.position.Set(position.x,position.y,0);
					}
					astro.gameObject.tag = "Up";
					break;
				}
			}
		}
	}
	
	public void goUpLevel(){
		//Debug.Break();
		lastMap=whichMap;
		whichMap--;
		reloadLevel();
	}
	
	public void goDownLevel(){
		lastMap=whichMap;
		whichMap++;
		reloadLevel();
	}
	
	private void reloadLevel(){
		if(Network.isServer)
			destroyMapOnline();
		if(whichMap==0||whichMap==maxMaps)
		{
			Network.Disconnect();
			Application.LoadLevel("startScene");
			return;
		}
		if (Network.isServer) {
			init ();
			generate ();
			//connected=true;
			//thisPlayer = (GameObject)Network.Instantiate(PlayerPrefab,
			//                                             spawnPosition.position, spawnPosition.rotation, 0);
			//cameraScript.Follow(thisPlayer);
			updatePlayerArray();
		}
		if (Network.isClient) {
			//thisPlayer = (GameObject)Network.Instantiate(PlayerPrefab,
			//                                             spawnPosition.position, spawnPosition.rotation, 0);
			//cameraScript.Follow(thisPlayer);
			updatePlayerArray();
		}
		thisPlayer.transform.position.Set(spawnPosition.position.x,spawnPosition.position.y,spawnPosition.position.z);
	}
	
	void Start(){
		Network.sendRate = 30;
		storeDataScript sd=GameObject.FindGameObjectWithTag("Database").GetComponent<storeDataScript>();
		if(sd.server){
			Network.InitializeServer(4,sd.portNumber,false);
		}
		else{
			Network.Connect(sd.connectionIP,sd.portNumber);
		}
//		healthBarlenght = Screen.width / dimbarDinscreen;
//		if (Network.isServer) {
//			init ();
//			generate ();
//			connected=true;
//			thisPlayer = (GameObject)Network.Instantiate(PlayerPrefab,
//			                                             spawnPosition.position, spawnPosition.rotation, 0);
//			cameraScript.Follow(thisPlayer);
//			updatePlayerArray();
//		}
//		if (Network.isClient) {
//			connected=true;
//			thisPlayer = (GameObject)Network.Instantiate(PlayerPrefab,
//			                                             spawnPosition.position, spawnPosition.rotation, 0);
//			cameraScript.Follow(thisPlayer);
//			updatePlayerArray();
//		}
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
    public static void AdjustcurHealth(float cur, float max) {
        maxHealth=max;
        if (cur < 0) {
            curHealth = 0;
        } else if (cur > maxHealth) {
            curHealth = maxHealth;
        } else {
            curHealth = cur;
        }
        hpbarDisplay = (curHealth / maxHealth);
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
