using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEditor;
using System.Collections.Generic;

public class TroopsGui : MonoBehaviour {
	public int buttonSpace = 20;
	public int buttonHeight = 40;
	public int buttonWidth = 90;
	public string tagName = "Enemy";
	public int test = 0;

	public Transform archer;
	public Transform warrior;
	public Transform catapult;

	private TroopPlace troopPlace;
	private List<GameObject> taggedObjects;
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
		int count = 0;
		GUI.Label (new Rect (buttonXPos + 3, buttonYPos - 25, 200, 30), "PURCHASE TROOPS");

		if (GUI.Button (new Rect (buttonXPos + count, buttonYPos, buttonWidth, buttonHeight), "Add Archer")) {
			if (!troopPlace.PlaceIsInProcess()) {
				troopPlace.DefineObjectName(archer);
			}
		}
		count += buttonWidth + buttonSpace;
		if (GUI.Button (new Rect (buttonXPos + count, buttonYPos, buttonWidth, buttonHeight), "Add Warrior")) {
			if (!troopPlace.PlaceIsInProcess()) {
				troopPlace.DefineObjectName(warrior);
			}
		}
		count += buttonWidth + buttonSpace;
		if (GUI.Button (new Rect (buttonXPos + count, buttonYPos, buttonWidth, buttonHeight), "Add Catapult")) {
			if (!troopPlace.PlaceIsInProcess()) {
				troopPlace.DefineObjectName(catapult);
			}
		}
		count += buttonWidth + buttonSpace;
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
