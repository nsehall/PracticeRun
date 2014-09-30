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
		if (objSet) {
			troop.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
			                                       Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 
			                                       troop.transform.position.z);
		}
	}

	public void DefineObjectName (GameObject obj) {
		if (!PlaceIsInProcess()) {
			objSet = true;
			troop = (GameObject) Instantiate (obj, Vector3.zero, Quaternion.AngleAxis (0.0f, Vector3.zero));
		}
	}

	public bool PlaceIsInProcess() {
		return objSet;
	}

	public void CancelTroopPlace() {
		objSet = false;
	}

	public bool AttemptTroopPlace() {
		Collider2D[] hits = Physics2D.OverlapPointAll (Camera.main.ScreenToWorldPoint(Input.mousePosition));
		for (int i = 0; i < hits.Length; i++) {
			if (hits[i].tag == "Walls") {
				if (hits[i].GetComponent<WallScript> ().AssignTroop(troop)) {
					return true;
				}
			}
		}
		
		objSet = false;

		return true;
	}
}
