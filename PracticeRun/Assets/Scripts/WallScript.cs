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
			Destroy(this.gameObject);
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

}