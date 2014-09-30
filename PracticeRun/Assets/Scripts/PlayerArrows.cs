using UnityEngine;
using System.Collections;

public class PlayerArrows : MonoBehaviour {

	public int damage = 1;
	public float speed = 2.0f;
	public float maxHeight = 10.0f;
	public Vector3 shotFrom;

	public Transform shotAt;

	public bool active = false;

	private Vector3 direction;
	private bool ascending = true;

	// Use this for initialization
	void Start () {
		shotFrom = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(active){
			if(ascending){
				direction = shotAt.transform.position - shotFrom;
				direction.Normalize();
				direction.y += 0.5f;
				
				rigidbody2D.velocity = direction * speed;
			}

			if(transform.position.y > shotFrom.y + maxHeight){
				ascending = false;
			}
			
			if(!ascending && shotAt != null){
				direction = shotAt.transform.position - transform.position;
				direction.Normalize();
				rigidbody2D.velocity = direction * speed;
			}
			
			if(shotAt == null){
				Destroy(this.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform == shotAt){
			shotAt.GetComponent<EnemyGeneral>().ReceiveDamage(damage);
			Destroy(this.gameObject);
		}
	}
}
