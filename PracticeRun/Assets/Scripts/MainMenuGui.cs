using UnityEngine;
using System.Collections;

public class MainMenuGui : MonoBehaviour {
	public int buttonSpace = 20;
	public int buttonHeight = 80;
	public int buttonWidth = 180;

	private ManagerScript managerScript;
	private bool menuShowing = false;
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
		DefineScreenWidth ();
		if (menuShowing) {
			ShowMainMenu ();
		} 
	}

	void ShowMainMenu() {
		GUI.Label (new Rect (buttonXPos + 65, buttonYPos - 25, buttonWidth, 30), "PAUSED");
		if (GUI.Button (new Rect (buttonXPos, buttonYPos, buttonWidth, buttonHeight), "Continue")) {
			HideMenu();
			managerScript.UnpauseGame();
		}
		if (GUI.Button (new Rect (buttonXPos, buttonYPos + (buttonHeight + buttonSpace), buttonWidth, buttonHeight), "Exit")) {
			Application.Quit();
		}
	}

	public void HideMenu() {
		menuShowing = false;
	}
	
	public void ShowMenu() {
		menuShowing = true;
	}

	public bool IsVisible() {
		return menuShowing;
	}

	private void DefineScreenWidth () {
		buttonYPos = (Screen.height - (buttonHeight * 2 + buttonSpace))/2;
		buttonXPos = (Screen.width - buttonWidth)/2;
	}
}
