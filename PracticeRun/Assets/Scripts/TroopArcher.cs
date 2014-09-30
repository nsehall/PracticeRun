using UnityEngine;
using System.Collections;

public class TroopArcher : TroopGeneral {

	public Transform arrowPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(state == PlayerState.Attacking && target != false && attackCooldown <= 0.0f){
			Transform arrow = (Transform)Instantiate(arrowPrefab);
			arrow.GetComponent<PlayerArrows>().shotAt = target.transform;
			arrow.GetComponent<PlayerArrows>().active = true;
			arrow.position = this.transform.position;

			attackCooldown = attackRate;
		}
	}
}
