using UnityEngine;
using System.Collections;

public class EnemyMelee : EnemyGeneral {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.tag == "Walls" && state == EnemyState.Attacking){
			if(attackCooldown <= 0){
				other.GetComponent<WallScript>().ReceiveDamage(damage);
				attackCooldown = attackRate;
			}
		}
	}
}
