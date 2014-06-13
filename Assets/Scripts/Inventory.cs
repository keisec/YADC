using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	private float _offset=10;
	private bool _displayInventoryWindow=false;
	private const int INVENTORY_WINDOW_ID=1;
	private Rect _inventoryWindowRect=new Rect(10,10,330,265);
	private int _inventoryRows=6;
	private int _inventoryCols=8;
	public float buttonWidth=40;
	public float buttonHeight=40;
	private List<Rect> actions;
	
	//private Vector2 _inventoryWindowSlider=Vector2.zero;
 	// Use this for initialization
	void Start () {
		actions=new List<Rect>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i"))
		{
			ToggleInventoryWindow();
		}
	}

	void OnGUI(){
		if (_displayInventoryWindow)
			_inventoryWindowRect = GUI.Window(INVENTORY_WINDOW_ID, _inventoryWindowRect, InventoryWindow, "Inventory");
		for(int i=0;i<actions.Count;i++){
			if(actions[i].Contains(Event.current.mousePosition)){
				if(Input.GetMouseButtonDown(0))
					Debug.Log(playerScript.Inventory[i]);
				if(Input.GetMouseButtonDown(1)){
					playerScript.Inventory[i].GetComponent<GenericItemScript>().drop(gameObject.transform.position);
					playerScript.Inventory.RemoveAt(i);
					actions.RemoveAt(i);
				}
				break;
			}
		}
	}
	public  void InventoryWindow(int id){
		int cnt = 0;
		actions.Clear();
		for (int i=0; i< _inventoryRows; i++)
			for(int j=0;j< _inventoryCols;j++)
				if((cnt++)<playerScript.Inventory.Count)
					actions.Add(new Rect(5+(j* buttonWidth ),20+(i*buttonHeight),  buttonWidth,buttonHeight));
		cnt=0;
		for (int i=0; i< _inventoryRows; i++) {
			for(int j=0;j< _inventoryCols;j++){
				if(cnt<playerScript.Inventory.Count){
					//GUI.Button(new Rect(5+(j* buttonWidth ),20+(i*buttonHeight),  buttonWidth,buttonHeight),playerScript.Inventory[cnt].name );
					GameObject go=playerScript.Inventory[cnt];
					GUI.DrawTexture(actions[cnt],go.GetComponent<GenericItemScript>().itemTexture);
				}
				else{
					//GUI.Label(new Rect(5+(j* buttonWidth ),20+(i*buttonHeight),  buttonWidth,buttonHeight),(j+i* _inventoryCols).ToString(),"box");
				}
				cnt++;
			}
		}
		GUI.DragWindow ();
	}
	public  void ToggleInventoryWindow(){
		_displayInventoryWindow = !_displayInventoryWindow;
	}
}