using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	
	public int health = 100;
	public bool occupied = false;
	private int children = 0;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ReceiveDamage(int damage){
		if (damage < health) {
			health = health - damage;
		} else {
			transform.position = Vector2.up * 1000;
			Destroy(this.gameObject, 0.5f);
		}
	}
	
	public bool IsOccupied() {
		children = transform.childCount;
			if(children > 0) {
			occupied = true;
			   } else {
			occupied = false;
		}
		return occupied;
    }

	//onclick assign troop's parent to wall
	public bool AssignTroop(Transform troopPrefab) {
		if (IsOccupied() == false) {
			Transform troop = (Transform)Instantiate (troopPrefab);
			troop.transform.position = this.transform.position;
			troop.transform.parent = this.transform;
			return true;
		    } else {
			return false;
		}
	}
}