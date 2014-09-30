using UnityEngine;
using System.Collections;

public class ManagerScript: MonoBehaviour {
	public int currency = 0;
	private TroopsGui troopsGui;
	private MainMenuGui mainMenuGui;
	private bool paused = false;

	void Awake () {
		troopsGui = GameObject.FindWithTag ("GUI").GetComponent<TroopsGui> ();
		mainMenuGui = GameObject.FindWithTag ("GUI").GetComponent<MainMenuGui> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckMainMenu ();
	}

	private void CheckMainMenu () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			troopsGui.ShowMenu();
			paused = true;
		}
	}
}
