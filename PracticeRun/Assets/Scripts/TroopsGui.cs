using UnityEngine;
using System.Collections;
using System.Linq;

public class TroopsGui : MonoBehaviour {
	const int buttonSpace = 20;
	const int buttonHeight = 40;
	const int buttonWidth = 90;

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
			DefineScreenWidth ();
			createButtons();
		} 
	}

	bool MenuShowing () {
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
			managerScript.currency += 50;
		}
	}

	void HideMenu() {
		menuShowing = false;
	}

	void ShowMenu() {
		menuShowing = true;
	}

	private void DefineScreenWidth () {
		buttonYPos = Screen.height - (buttonHeight + buttonSpace);
		buttonXPos = buttonSpace;
	}
}
