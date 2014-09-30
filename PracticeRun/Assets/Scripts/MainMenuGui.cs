using UnityEngine;
using System.Collections;

public class MainMenuGui : MonoBehaviour {
	const int buttonSpace = 20;
	const int buttonHeight = 80;
	const int buttonWidth = 180;

	private ManagerScript managerScript;
	private bool menuShowing = true;
	private int buttonYPos;
	private int buttonXPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (menuShowing) {
			DefineScreenWidth ();
		} 
	}

	void CreateButtons() {
		if (GUI.Button (new Rect (buttonXPos, buttonYPos, buttonWidth, buttonHeight), "Continue")) {
			managerScript.currency += 50;
			HideMenu();
		}
		if (GUI.Button (new Rect (buttonXPos, buttonYPos, buttonWidth, buttonHeight), "Add Archers")) {
			managerScript.currency += 50;
			HideMenu();
		}
		if (GUI.Button (new Rect (buttonXPos, buttonYPos, buttonWidth, buttonHeight), "Exit")) {
			managerScript.currency += 50;
			HideMenu();
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
