using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Spawns anything not player. 
public class SpawnObjects : MonoBehaviour {

	[SerializeField]
	private float spawnDistance;

	// Generic formula to check if the objects spawning are close to the player.  
	private bool TooCloseToPlayer(GameObject player, Tile tile) {
		float playerX =  player.transform.position.x;
		float playerY =  player.transform.position.y;

		float tileX =  tile.GetX();
		float tileY =  tile.GetY();

		float x =  Mathf.Pow ((playerX - tileX), 2);
		float y =  Mathf.Pow ((playerY - tileY), 2);

		return ( Mathf.Sqrt(x+y) < spawnDistance);
	}

	/*
	 * This spawns everything besides player. It spawns chests, trashmobs, bosses etc. 
	 * GameObject[] things is the array of gameobjects containing the objects that will spawn.
	 */
	public void SpawnThings(int fillPercent, Space largestSpace, GameObject[] things, GameObject player, GameObject parent) {
		List<Tile> spawnList = largestSpace.GetTiles();
		
		for(int i = 0; i < fillPercent; i++) {
			int largestIndex = largestSpace.GetTiles().Count;
			int spawnPoint = UnityEngine.Random.Range(0, largestIndex);
			
			Tile tile = spawnList[spawnPoint];
			if (!tile.GetBusyStatus() && !TooCloseToPlayer(player, tile)) {
				
				int spawnThing = UnityEngine.Random.Range(0, things.Length);
				GameObject thing = things[spawnThing];
				GameObject instance = (GameObject) Instantiate(thing, new Vector3(tile.GetX()*0.32f, tile.GetY()*0.32f, 0), Quaternion.identity);

                instance.transform.SetParent(parent.transform);
			}
		}	
	}
}

