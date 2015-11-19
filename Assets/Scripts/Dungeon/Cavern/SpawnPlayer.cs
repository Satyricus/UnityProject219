using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;

// This class spawns player. 
public class SpawnPlayer : MonoBehaviour {

	SpaceDFS dfs;

	

	public void PlayerSpawn(GameObject player) {
		dfs = GetComponent<SpaceDFS>();

		Tile spawnTile = dfs.GetSpawnTile();
		Vector3 position = new Vector3 (spawnTile.GetX() * 0.32f , spawnTile.GetY() * 0.32f , 0);
		player.transform.position = position;
		spawnTile.SetIsBusy();
	}
	
}
