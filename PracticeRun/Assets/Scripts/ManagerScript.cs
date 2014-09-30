using UnityEngine;
using System.Collections;

public class ManagerScript: MonoBehaviour {
	public int currency = 0;

	private TroopsGui troopsGui;
	private MainMenuGui mainMenuGui;
	private TroopPlace troopPlace;
	private bool paused = false;

	void Awake () {
		troopsGui = GameObject.FindWithTag ("GUI").GetComponent<TroopsGui> ();
		mainMenuGui = GameObject.FindWithTag ("GUI").GetComponent<MainMenuGui> ();
		troopPlace = GameObject.FindWithTag ("Manager").GetComponent<TroopPlace> ();
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
			if (mainMenuGui.IsVisible()) {
				mainMenuGui.HideMenu();
				UnpauseGame ();
			} else {
				mainMenuGui.ShowMenu ();
				PauseGame ();
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			MouseDownEvent();
		}
		if (Input.GetMouseButtonDown (1)) {
			troopsGui.ShowMenu();
		}
	}

	public bool IsPaused () {
		return paused;
	}

	public void PauseGame () {
		paused = true;
	}

	public void UnpauseGame () {
		paused = false;
	}

	private void MouseDownEvent() {
		if (!IsPaused ()) {
			if (troopPlace.PlaceIsInProcess()) {
				troopPlace.CancelTroopPlace();
			} else {

			}
		}
	}
}
