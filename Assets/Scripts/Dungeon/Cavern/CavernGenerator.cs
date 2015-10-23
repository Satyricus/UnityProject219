using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/**
 *
 * This class is responsible for cavern generation and cavern management. Things like spawn a map, spawning player and enemies, spawning camera etc are all handled in this class. 
 * 
 * 
 * 
 * TODO (Priority low) : set properties for the spaces (Small, Which is the starting space etc... ) 
 * 
 * TODO (Future): create a passage between spaces. 
 * 
 * 
 */
public class CavernGenerator : MonoBehaviour {



	// The next two variables are placeholder.  In the finished version we want to chose floor tile from multiple objects.
	[SerializeField]
	private GameObject ground;

	[SerializeField]
	private GameObject wall;

	[SerializeField]
	private GameObject[] trashMobs; // Regular non boss enemies. 

	[Range(1,100)]
	public int trashMobsNumber;

	/*[SerializeField]
	private GameObject[] bossEnemies;*/ // For use later. 

	[SerializeField]
	private int width;

	[SerializeField]
	private int height;

	[SerializeField]
	private string Randomiser;

	private Tile spawnTile;
	private Space largestSpace;

	CameraFollow cam;


	Tile[,] tiles;
	
	private List<Space> spaces = new List<Space>();
	
	[Range(0,100)]
	public int fillPercent;
	
	int[,] map;

	GameObject player;
	
	void Start() {
		player = GameObject.Find("Player");
		tiles = new Tile[width,height];
		GenerateMap();

		cam = GetComponent<CameraFollow> ();
	
		RunThroughGraph();

		DrawMap ();

		DecideLargestSpace ();

		SpawnPlayer ();
	}

	void CreateTile(int x, int y) {
		bool walled = (map[x,y] == 0)? false : true;
		bool adj = !(GetAdjacentWallCount(x,y) == 0);
		Tile tile = new Tile(x, y, walled, adj);
		tiles[x,y] = tile;
	}

	/**
	* Runs through graph and runs DFS on the tiles. 
	* 
	* 
	* If this tile is !isDiscovered and isn't a wallCount.
	* Add to the spaces, run the DFS through dFS.
	*/
	public void RunThroughGraph() {
		
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if (!tiles[x,y].IsDiscovered() && !tiles[x,y].IsWall() ) {
					Space tmp = new Space();
					DFS(tiles[x,y], tmp);
					spaces.Add(tmp);
				} 
			}
		}
	}
	
	/**
	* Depth First Search To traverse the map we currently have. 
	* 
	* -----------------------------
	* 111111111111111111111111111111
	* 111111111111100111111111111111
	* 111111111100000000011111111111
	* 111110000000000000000000000111
	* 110001100000000000000011000011
	* 110001000000000001111111111111
	* 111000000000000111111111111111
	* 111111000000111111111111111111
	* 111111110001111111111111111111
	* 111111111011111111111111111111
	* 111111111111111111111111111111
	* 
	* left = [x-1,y]
	* right = [x+1,y]
	* up = [x,y+1]
	* down = [x,y-1]
	*/
	public void DFS(Tile startNode, Space tmp) {

		if (startNode.IsAdjacentToWall())
			tmp.addOuterTile(startNode);

		else {
			tmp.addTile(startNode);
		}

		startNode.DiscoverNode();
		
		int x = (int) startNode.GetX();
		int y = (int) startNode.GetY();

		// Goes left.
		if ((startNode.GetX() > 0) && (!this.tiles[x-1,y].IsWall()) && (!this.tiles[x-1,y].IsDiscovered())) {
			DFS(this.tiles[x-1,y], tmp);
		}
		
		// Goes right.
		if ((startNode.GetX() < this.width-1) && (!this.tiles[x+1, y].IsWall()) && (!this.tiles[x+1, y].IsDiscovered())) {
			DFS(this.tiles[x+1, y], tmp);
		}
		
		//Goes down.
		if ((startNode.GetY() < this.height-1) && (!this.tiles[x, y+1].IsWall()) && (!this.tiles[x, y+1].IsDiscovered())) {
			DFS(this.tiles[x, y+1], tmp);
		}
		
		if ((startNode.GetY() > 0) && (!this.tiles[x, y-1].IsWall()) && (!this.tiles[x, y-1].IsDiscovered())) {
			DFS(this.tiles[x, y-1], tmp);
		}
	} 


	
	void GenerateMap() {
		map = new int[width,height];
		RandomFillMap();
		
		for (int i = 0; i < 5; i ++) {
			SmoothMap();
		}
	}
	
	
	void RandomFillMap() {
		Randomiser = UnityEngine.Random.Range (-10000000,10000000).ToString();
		
		System.Random pseudoRandom = new System.Random(Randomiser.GetHashCode());
		
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				if (x == 0 || x == width-1 || y == 0 || y == height -1) {
					map[x,y] = 1;
				}
				else {
					map[x,y] = (pseudoRandom.Next(0,100) < fillPercent)? 1: 0;
				}
			}
		}
	}
	
	void SmoothMap() {
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				int neighbourWallTiles = GetAdjacentWallCount(x,y);
				
				if (neighbourWallTiles > 4)
					map[x,y] = 1;
				else if (neighbourWallTiles < 4)
					map[x,y] = 0;

				CreateTile(x,y);
			}
		}
	}

	/*
	 *  Returns the number of walls to a tile. 
	 */
	int GetAdjacentWallCount(int x, int y) {
		int wallCount = 0;
		for (int neighbourX = x - 1; neighbourX <= x + 1; neighbourX ++) {
			for (int neighbourY = y - 1; neighbourY <= y + 1; neighbourY ++) {
				if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
					if (neighbourX != x || neighbourY != y) {
						wallCount += map[neighbourX,neighbourY];
					}
				}
				else {
					wallCount ++;
				}
			}
		}
		
		return wallCount;
	}



	/**
	 * Will decide the largest space in map and choose spawning point for player (most southern point in the largest space).
	 */
	void DecideLargestSpace() {

		foreach (Space space in spaces) {
			if (largestSpace == null)
				largestSpace = space;

			if (largestSpace.NumberOfTiles() < space.NumberOfTiles())
				largestSpace = space;
		}
		// Spawns player in the most southern tile in the space. 
		spawnTile = largestSpace.GetSouthernTile ();

	}


	void SpawnPlayer() {
		Vector3 position = new Vector3 (spawnTile.GetX() * 0.32f , spawnTile.GetY() * 0.32f , 0);
		player.transform.position = position;
	}

	void SpawnTrashMobs() {

	}


	/**
	 * Draw the map. 
	 * Our tile sprites are 32-bit so 32 pixels far. 
	 */
	void DrawMap() {
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				// Is the tile ground? Wall?
				GameObject tile =(map[x,y] == 0)? ground : wall;
				Vector3 position = new Vector3(x*0.32f, y*0.32f,0);

				// I've used this a couple of times and I still don't get Quaternion Identity. 
				// Instansiates a gameObject. Need to find a way to hide it in the hirearchy as child to another game object. 
				Instantiate(tile,position, Quaternion.identity);

			}
		}
	}
	
}