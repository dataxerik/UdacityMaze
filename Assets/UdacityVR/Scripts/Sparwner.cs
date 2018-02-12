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
		int maxRange = locations.Length;
		int indexToSpawn = Random.Range (0, maxRange);
		//key.transform.position = locations [indexToSpawn].transform.localPosition;
		maxRange--;
		System.Random rand = new System.Random ();
		List<int> listOfNumbers =
			Enumerable.Range (0, locations.Length).OrderBy (x => rand.Next ()).Take (locations.Length).ToList ();
		bool spawnedKey = false;
		foreach (int i in listOfNumbers) {
			print ("hi");
			print (i + " location is " + locations [i].transform.localPosition);
			if (!spawnedKey) {
				print ("in spawn key");
				Key key = Instantiate (keyPrefab) as Key;
				print (key.transform.position);
				key.transform.position = locations [i].transform.position;

				spawnedKey = true;
				print (key.transform.position);
			} else {
				Coin coin = Instantiate (coinPrefab) as Coin;
				coin.transform.position = locations [i].transform.position;
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
