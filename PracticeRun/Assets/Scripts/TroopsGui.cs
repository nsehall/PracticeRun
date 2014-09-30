using UnityEngine;
using System.Collections;
using System.Linq;

public class TroopsGui : MonoBehaviour {
	public int buttonSpace = 20;
	public int buttonHeight = 40;
	public int buttonWidth = 90;
	public string tagName = "Enemy";
	public int test = 0;

	private TroopPlace troopPlace;

	private bool menuShowing = false;
	private int buttonYPos;
	private int buttonXPos;

	void Awake() {
		troopPlace = GameObject.FindWithTag ("Manager").GetComponent<TroopPlace> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if (menuShowing) {
			DefineScreenWidth ();
			createButtons();
		} 
	}

	public bool MenuShowing () {
		return menuShowing;
	}


	private void createButtons () {
		var taggedObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag==tagName).ToList();
		test = taggedObjects.Count () + 1;
		GUI.Label (new Rect (buttonXPos + 3, buttonYPos - 25, 200, 30), "PURCHASE TROOPS");
		foreach (GameObject o in taggedObjects) {
			if (GUI.Button (new Rect (buttonXPos, buttonYPos, buttonWidth, buttonHeight), "Add " + o.name)) {
				if (troopPlace.PlaceIsInProcess()) {
					troopPlace.DefineObjectName(o.name);
					HideMenu();
				}
			}
		}
	}

	public void HideMenu() {
		menuShowing = false;
	}

	public void ShowMenu() {
		menuShowing = true;
	}

	private void DefineScreenWidth () {
		buttonYPos = Screen.height - (buttonHeight + buttonSpace);
		buttonXPos = buttonSpace;
	}
}
