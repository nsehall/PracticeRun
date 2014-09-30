using UnityEngine;
using System.Collections;

public class Currency : MonoBehaviour {

    public int currency = 100;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PlusCurrency (int amount) {
		currency = currency + amount;
	}

	public void MinusCurrency (int amount) {
		currency = currency - amount;
	}

}
