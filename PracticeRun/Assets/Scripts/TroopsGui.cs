using UnityEngine;
using System.Collections;
using System.Linq;

public class TroopsGui : MonoBehaviour {
	const int buttonSpace = 20;
	const int buttonHeight = 40;
	const int buttonWidth = 90;

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

	private void TroopRequest () {

	}

	private void createButtons () {
		var taggedObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag=="troops").ToList();

		GUI.Label (new Rect (buttonXPos + 3, buttonYPos - 25, 200, 30), "PURCHASE TROOPS");
		foreach (GameObject o in taggedObjects) {

		}
		if (GUI.Button (new Rect (buttonXPos, buttonYPos, buttonWidth, buttonHeight), "Add Archers")) {
			if (troopPlace.PlaceIsInProcess()) {
				HideMenu();
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
