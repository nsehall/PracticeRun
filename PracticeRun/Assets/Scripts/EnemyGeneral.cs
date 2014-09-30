using UnityEngine;
using System.Collections;

public class EnemyGeneral : MonoBehaviour {

	public int health = 20;
	public int damage = 1;
	public float attackRate = 0.5f;
	public float speed = 2.0f;
	public Vector2 direction = new Vector2(0.5f, -0.5f);
	public GameObject spawnedFrom;

	public enum EnemyState{
		Moving,
		Attacking,
		Dead
	}

	public EnemyState state;

	public float attackCooldown = 0.0f;

	// Use this for initialization
	void Start () {
		state = EnemyState.Moving;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch(state){
		case EnemyState.Moving:
			rigidbody2D.velocity = direction * speed;
			break;

		case EnemyState.Attacking:
			rigidbody2D.velocity = Vector2.zero;

			if(attackCooldown > 0){
				attackCooldown -= Time.deltaTime;
			}
			break;

		case EnemyState.Dead:
			if(spawnedFrom != null){
				spawnedFrom.GetComponent<EnemySpawner>().numSpawned--;
			}
			Destroy(this.gameObject);
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Walls"){
			state = EnemyState.Attacking;
		}
	}

	public void ReceiveDamage(int damage){
		health -= damage;

		if(health <= 0){
			state = EnemyState.Dead;
		}
	}
	
}
