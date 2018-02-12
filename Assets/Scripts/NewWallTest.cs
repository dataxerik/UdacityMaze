using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWallTest : MonoBehaviour {
	public MazeWall wallPrefab;
	// Use this for initialization
	void Start () {
		MazeWall wall = Instantiate (wallPrefab) as MazeWall;
		wall.transform.parent = this.transform;
		wall.transform.localPosition = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
