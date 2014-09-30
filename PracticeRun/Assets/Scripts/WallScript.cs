using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	
	public int health = 100;
	public bool occupied = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ReceiveDamage(int damage){
		if (damage > health) {
			health = health - damage;
		} else {
			Destroy(this.gameObject);
		}
	}
	
	//public bool IsOccupied() {
		//Transform[] children = 
			//if(this.gameObject.get
			   //}
    //}

}