using UnityEngine;
using System.Collections;

public class charCreation : MonoBehaviour {
	private bool showList= false;
	public  int listEntry= 0;
	public  GUIContent[] list;
	private GUIStyle listStyle;
	private bool picked= false;
	public string nickname="";
	public string eroare1="eroare: nickname deja inregistrat";
	public string eroare2="eroare: nickname prea scurt";

	public bool exista=true;
	private string errorMessage="";
	public int lungimeMinNickname=5;

	void  Start (){
		// Make some content for the popup list
		list = new GUIContent[4];
		list[0] = new GUIContent("Warrior");
		list[1] = new GUIContent("Wizard");
		list[2] = new GUIContent("Rogue");
		list[3] = new GUIContent("Bard");
		
		
		// Make a GUIStyle that has a solid white hover/onHover background to indicate highlighted items
		listStyle = new GUIStyle();
		listStyle.normal.textColor = Color.white;
		Texture2D tex= new Texture2D(2, 2);
		Color[] colors= new Color[4];
		
		for(int i=0;i<4;i++)colors[i]=Color.white;
		tex.SetPixels(colors);
		tex.Apply();
		listStyle.hover.background = tex;
		listStyle.onHover.background = tex;
		listStyle.padding.left = listStyle.padding.right = listStyle.padding.top = listStyle.padding.bottom = 4;
	}
	
	void  OnGUI (){
		if (Popup.List (new Rect (75, Screen.height -100, 200, 50), ref showList, ref listEntry, new GUIContent (list [listEntry].text), list, listStyle)) {
						picked = true;
				}
				if (list [listEntry].text.Equals ("Warrior"))
			GUI.Label (new Rect (50, 70,  250, Screen.height -200), "descriere " + list [listEntry].text + "!","box");
				else {
						if (list [listEntry].text.Equals ("Wizard")) {
				GUI.Label (new Rect (50, 70, 250, Screen.height -200), "descriere " + list [listEntry].text + "!","box");
						} else {
								if (list [listEntry].text.Equals ("Rogue")) {
					GUI.Label (new Rect (50, 70,  250, Screen.height -200), "descriere " + list [listEntry].text + "!","box");
								} else {
					GUI.Label (new Rect (50, 70,  250, Screen.height -200), "descriere " + list [listEntry].text + "!","box");
								}

						}
				}

				nickname = GUI.TextField (new Rect (Screen.width / 2 - 100, Screen.height -250, 200, 50), nickname);
		GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height -200, 200, 50), errorMessage);
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height -150, 200, 50), "Create")) {
						if (true) { //existenta nicname in baza de date modifica "true" cu scriptul de sql
								exista = true;
						}
						if (exista == false)
						if (nickname.Length >= lungimeMinNickname)

					//insert
								Application.LoadLevel ("startScene");
						else {
								errorMessage = eroare2;	
						}
						else {
								errorMessage = eroare1;
						}
			exista = false;
				}

		if (GUI.Button (new Rect (Screen.width-300, Screen.height -100,200,50),"Back"))
		{
			Application.LoadLevel("startScene");
		}
		}
	void Update() {
	
	}
}


