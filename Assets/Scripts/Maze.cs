﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
	public float generateStepDelay;
	public MazeCell cellPrefab;
	public MazePassage passagePrefab;
	public MazeWall[] wallPrefabs;
	private MazeCell[,] cells;

	//public IntVector2 coordinates;
	public IntVector2 size;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public MazeCell GetCell (IntVector2 coordinates) {
		return cells [coordinates.x, coordinates.z];
	}

	public IEnumerator Generate() {
		WaitForSeconds delay = new WaitForSeconds (generateStepDelay);
		cells = new MazeCell[size.x, size.z];
		List<MazeCell> activeCells = new List<MazeCell> ();
		DoFirstGenerationStep (activeCells);
		while (activeCells.Count > 0) {
				yield return delay;
				DoNextGenerationStep (activeCells);
		}
	}

	private MazeCell CreateCell(IntVector2 coordinates){
		MazeCell newCell = Instantiate (cellPrefab) as MazeCell;
		cells [coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + " , " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = 
			new Vector3 (coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
		return newCell;
	}

	public IntVector2 RandomCoordinates {
		get {
			return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
			}
	}

	public bool ContainsCoordinates(IntVector2 coordinates) {
		return coordinates.x >= 0 && coordinates.x < size.x && coordinates.z >= 0 && coordinates.z < size.z;
	}

	private void DoFirstGenerationStep(List<MazeCell> activeCells) {
		activeCells.Add (CreateCell (RandomCoordinates));
	}

	private void DoNextGenerationStep(List<MazeCell> activeCells) {
		int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells[currentIndex];
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt (currentIndex);
			return;
		}
		MazeDirection direction = currentCell.RandomUninitializedDirection;
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2 ();
		if (ContainsCoordinates (coordinates)) {
			MazeCell neighbor = GetCell (coordinates);
			if (neighbor == null) {
				neighbor = CreateCell (coordinates);
				CreatePassage (currentCell, neighbor, direction);
				activeCells.Add (neighbor);
			} else {
				CreateWall (currentCell, neighbor, direction);
				//activeCells.RemoveAt (currentIndex);
			}
		} else {
			CreateWall (currentCell, null, direction);
			//activeCells.RemoveAt (currentIndex);
		}
	}

	private void CreatePassage(MazeCell cell, MazeCell otherCell, MazeDirection direction){
		MazePassage passage = Instantiate (passagePrefab) as MazePassage;
		passage.Initialize (cell, otherCell, direction);
		passage = Instantiate (passagePrefab) as MazePassage;
		passage.Initialize (otherCell, cell, direction.GetOpposite ());
	}

	private void CreateWall(MazeCell cell, MazeCell otherCell, MazeDirection direction){
		MazeWall wall = Instantiate (wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
		wall.Initialize (cell, otherCell, direction);
		if (otherCell != null) {
			wall = Instantiate (wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
			wall.Initialize (otherCell, cell, direction.GetOpposite());
		}
	}
}
