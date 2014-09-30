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

	void Awake () {
		managerScript = GameObject.FindWithTag ("Manager").GetComponent<ManagerScript> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (menuShowing) {
			ShowMainMenu ();
		} 
	}

	void ShowMainMenu() {
		if (GUI.Button (new Rect (buttonXPos, buttonYPos, buttonWidth, buttonHeight), "Continue")) {
			HideMenu();
			managerScript.UnpauseGame();
		}
		if (GUI.Button (new Rect (buttonXPos, buttonYPos + buttonHeight + buttonSpace, buttonWidth, buttonHeight), "Settings")) {
			HideMenu();
		}
		if (GUI.Button (new Rect (buttonXPos, buttonYPos + 2 * (buttonHeight + buttonSpace), buttonWidth, buttonHeight), "Exit")) {
			Application.Quit();
		}
	}

	public void HideMenu() {
		menuShowing = false;
	}
	
	public void ShowMenu() {
		menuShowing = true;
	}

	private void DefineScreenWidth () {
		buttonYPos = (Screen.height - (buttonHeight * 3 + buttonSpace * 2))/2;
		buttonXPos = (Screen.width - buttonWidth)/2;
	}
}
