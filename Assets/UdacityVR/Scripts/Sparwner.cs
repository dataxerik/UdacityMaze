using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sparwner : MonoBehaviour {

	public GameObject[] locations;
	public Key keyPrefab;
	public Coin coinPrefab;
	private const int numberOfCoins = 5;
	private const int numberOfKeys = 1;

	void Awake() {
		locations = GameObject.FindGameObjectsWithTag ("SpawnLocation");
		System.Random rand = new System.Random ();
		List<int> listOfNumbers =
			Enumerable.Range (0, locations.Length).OrderBy (x => rand.Next ()).Take (locations.Length).ToList ();
		bool spawnedKey = false;
		int counter = 0;
		foreach (int i in listOfNumbers) {
			if (counter+1 > numberOfCoins) {
				break;
			}

			if (!spawnedKey) {
				Key key = Instantiate (keyPrefab) as Key;
				key.transform.parent = locations [i].transform;
				key.transform.localPosition = locations [i].transform.position;
				spawnedKey = true;
			} else {
				Coin coin = Instantiate (coinPrefab) as Coin;
				coin.transform.parent = locations [i].transform;
				coin.transform.position = locations [i].transform.position;
				coin.transform.localPosition = new Vector3 (0, 1.3f, 0);
			}

			counter++;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
