using UnityEngine;
using System.Collections;

public class PopupListChar : MonoBehaviour {
	private bool showList= false;
	private int listEntry= 0;
	private GUIContent[] list;
	private GUIStyle listStyle;
	private bool picked= false;
	public int pozx=0;
	public int pozy=0;
	public int nrCaractere=1;
	void  Start (){
		// Make some content for the popup list
		list = new GUIContent[nrCaractere];
		for(int i=0;i<nrCaractere;i++)
		list[i] = new GUIContent("numeCaracter");

		
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
		if (Popup.List ( new Rect(pozx, pozy, 200, 50),ref showList,ref listEntry,new GUIContent(list[listEntry].text), list, listStyle)) {
			picked = true;
		}
		if(picked)
			GUI.Label ( new Rect(50, 70, 400, 20), "You picked " + list[listEntry].text + "!");

	}
	void Update() {
		 pozx=(Screen.width/2)-100;
		pozy = ( 2 * Screen.height / 3) +50;
	}
}
