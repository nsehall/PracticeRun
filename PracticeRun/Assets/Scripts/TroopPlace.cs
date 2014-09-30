using UnityEngine;
using System.Collections;
using System.Linq;

public class TroopPlace : MonoBehaviour {
	private GameObject troop;
	private bool objSet = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DefineObject (string name) {
		if (!PlaceIsInProcess()) {
			objSet = true;
			GameObject troop = Resources.FindObjectsOfTypeAll (typeof(GameObject)).Cast<GameObject> ().Where (g => g.name == name);
			Instantiate (troop, Vector3.zero, Quaternion.AngleAxis (0.0f, Vector3.zero));
		}
	}

	public bool PlaceIsInProcess() {
		return objSet;
	}

	public bool AttemptTroopPlace() {
		Collider2D[] hits = Physics2D.OverlapPointAll (Camera.main.ScreenToWorldPoint(Input.mousePosition));

		return false;
	}
}
