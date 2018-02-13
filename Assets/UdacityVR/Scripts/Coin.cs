using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab
	public GameObject coinProofPrefab;
	const float rotationPerMinute = 10.0f;

	void Update(){
		transform.Rotate (0, 6.0f * rotationPerMinute * Time.deltaTime, 0);
	}

    public void OnCoinClicked() {
        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically
        // Destroy this coin. Check the Unity documentation on how to use Destroy
		GameObject coinProof = Instantiate(coinProofPrefab);
		coinProof.transform.position = this.transform.position;
		coinProof.transform.rotation = Quaternion.Euler (new Vector3 (-90, 0, 0));
		Destroy (this.gameObject);
    }

}
