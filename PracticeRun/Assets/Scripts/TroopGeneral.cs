using UnityEngine;
using System.Collections;

public class TroopGeneral : MonoBehaviour {

	public int health = 10;
	public int damage = 1;
	public float moveSpeed = 0.0f;
	public float attackRate = 2.0f;
	public float minRange = 20.0f;
	public float maxRange = 100.0f;

	public enum PlayerState{
		Idle,
		Moving,
		Attacking,
		Dead
	}

	public PlayerState state;
	public float attackCooldown = 0.0f;
	public Transform target;

	private float distanceFromTarget = 0.0f;

	// Use this for initialization
	void Start () {
		state = PlayerState.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null && state != PlayerState.Dead){
			Vector2 dis = transform.position - target.position;
			distanceFromTarget = dis.magnitude;
			if(distanceFromTarget > minRange && distanceFromTarget < maxRange){
				state = PlayerState.Attacking;
			} else if((distanceFromTarget > maxRange || distanceFromTarget < minRange) && moveSpeed == 0.0f){
				target = null;
				state = PlayerState.Idle;
			} else if(distanceFromTarget > maxRange){
				state = PlayerState.Moving;
			}
		}

		switch(state){
		case PlayerState.Idle:

			break;

		case PlayerState.Moving:

			break;

		case PlayerState.Attacking:
			if(target == null && state != PlayerState.Dead){
				state = PlayerState.Idle;
			}

			attackCooldown -= Time.deltaTime;
			break;

		case PlayerState.Dead:
			transform.position = Vector2.up * 1000;
			Destroy(this.gameObject, 0.5f);
			break;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if(target == null && other.tag == "Enemy"){
			target = other.transform;
		}
	}
}
