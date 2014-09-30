using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public float startDelay = 1.0f;
	public float spawnRate = 3.0f;
	public int maxExist = 20;
	public int numSpawned = 0;

	private bool active = false;
	private float spawnCooldown = 0.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine("StartDelay");
	}
	
	// Update is called once per frame
	void Update () {
		if(active){
			if(spawnCooldown > 0){
				spawnCooldown -= Time.deltaTime;
			}

			if(spawnCooldown <= 0 && numSpawned < maxExist){
				Transform enemy = (Transform)Instantiate(enemyPrefab);
				enemy.transform.position = this.transform.position;
				enemy.GetComponent<EnemyGeneral>().spawnedFrom = this.gameObject;
				spawnCooldown = spawnRate;
				numSpawned++;
			}

		}
	}

	IEnumerator StartDelay(){
		yield return new WaitForSeconds(startDelay);
		active = true;
	}
}
