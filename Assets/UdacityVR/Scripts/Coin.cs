using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab
	public GameObject coinProofPrefab;

    public void OnCoinClicked() {
        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically
        // Destroy this coin. Check the Unity documentation on how to use Destroy
		GameObject coin = Instantiate(coinProofPrefab);
		coin.transform.position = this.transform.position;
		coin.transform.rotation = Quaternion.Euler (new Vector3 (-90, 0, 0));
		Destroy (this.gameObject);
    }

}
