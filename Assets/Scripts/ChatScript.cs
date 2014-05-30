using UnityEngine;
using System.Collections;

public class ChatScript : MonoBehaviour {

	bool usingChat=false;
	bool showChat=false;

	Vector2 scrollPosition;
	int width=500;
	int height=400;
	Rect window;

	float lastUnfocusTime=0;
	string inputField="";
	string userName;

	ArrayList usersList=new ArrayList();
	class UserNode
	{
		public string userName;
		public NetworkPlayer user;
	}

	ArrayList chatEntries=new ArrayList();
	class ChatEntry
	{
		public string name="";
		public string text="";
	}

	void Start () 
	{
		window=new Rect(Screen.width/2-width/2,Screen.height/2-height+5,width,height);	
		userName=PlayerPrefs.GetString("username","");
		if (userName=="")
			userName="RandomName"+Random.Range(1,999);

	}

	void OnConnectedToServer()
	{
		ShowChatWindow();
		networkView.RPC("TellServerOurName",RPCMode.Server,userName);
		addGameChatMessage(userName+" s-a conectat pe Chat.");
	}

	void OnServerInitialised()
	{
		ShowChatWindow();
		UserNode newNode=new UserNode();
		newNode.user=Network.player;
		newNode.userName=userName;
		usersList.Add(newNode);
		addGameChatMessage(userName+" s-a conectat pe Chat.");
	}

	UserNode GetPlayerNode(NetworkPlayer player)
	{
		foreach (UserNode entry in usersList)
		{
			if (entry.user==player)
				return entry;
		}
		Debug.Log("Jucatorul cerut nu exista in Chat!");
		return null;
	}

	void OnPlayerDisconected(NetworkPlayer player)
	{
		addGameChatMessage("Un jucator s-a deconectat de la Chat.");
		usersList.Remove(GetPlayerNode(player));
	}

	void OnDisconnectedFromServer()
	{
		CloseChatWindow();
	}

	[RPC]
	void TellServerOurName(string name,NetworkMessageInfo info)
	{
		UserNode newNode=new UserNode();
		newNode.user=Network.player;
		newNode.userName=userName;
		usersList.Add(newNode);
		addGameChatMessage(userName+" s-a conectat pe Chat.");
	}

	void CloseChatWindow()
	{
		showChat=false;
		inputField="";
		chatEntries=new ArrayList();

	}

	void ShowChatWindow()
	{
		showChat=true;
		inputField="";
		chatEntries=new ArrayList();
	}

	void OnGUI()
	{
		if (!showChat)
			return;
		if (Event.current.type==EventType.keyDown && Event.current.character=='\n' && inputField.Length<=0)
		{
			if (lastUnfocusTime+.25f<Time.time)
			{
				usingChat=true;
				GUI.FocusWindow(5);
				GUI.FocusControl("Chat input field");
			}
		}
		window=GUI.Window(5,window,GlobalChatWindow,"");
	}

	void GlobalChatWindow(int id)
	{
		GUILayout.BeginVertical();
		GUILayout.Space(10);
		GUILayout.EndVertical();

		scrollPosition=GUILayout.BeginScrollView(scrollPosition);
		foreach (ChatEntry entry in chatEntries)
		{
			GUILayout.BeginHorizontal();
			if (entry.name==" - ")
				GUILayout.Label(entry.name+entry.text);
			else
				GUILayout.Label(entry.name+" : "+entry.text);
			GUILayout.EndHorizontal();
			GUILayout.Space(2);
		}

		GUILayout.EndScrollView();
		if (Event.current.type==EventType.keyDown && Event.current.character=='\n' && inputField.Length>0)
			HitEnter(inputField);
		GUI.SetNextControlName("Chat input field");
		inputField=GUILayout.TextField(inputField);

		if (Input.GetKeyDown("mouse 0"))
		{
			if (usingChat)
			{
				usingChat=false;
				GUI.UnfocusWindow();
				lastUnfocusTime=Time.time;
			}
		}
	}

	void HitEnter(string message)
	{
		message=message.Replace('\n',' ');
		networkView.RPC("ApplyGlobalChatText",RPCMode.All,userName,message);
	}

	[RPC]
	void ApplyGlobalChatText(string name, string msg)
	{
		ChatEntry entry=new ChatEntry();
		entry.name=name;
		entry.text=msg;

		chatEntries.Add(entry);

		//see only 4 chat entries at once
		if (chatEntries.Count>4)
			chatEntries.RemoveAt(0);

		scrollPosition.y=1000000;
		inputField="";

	}

	void addGameChatMessage(string str)
	{
		ApplyGlobalChatText(" - ",str);
		if (Network.connections.Length>0)
			networkView.RPC("ApplyGlobalChatText",RPCMode.Others," - ",str);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
