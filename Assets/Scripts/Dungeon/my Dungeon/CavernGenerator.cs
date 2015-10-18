using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/**
 *
 * This class is responsible for cavern generation,
 * 
 * TODO (Highest priority): Check the properties of spaces. 
 * 
 * TODO: set properties for the spaces (Small, Which is the starting space etc... )
 * 
 * TODO: create a passage between spaces. 
 * 
 */
public class CavernGenerator : MonoBehaviour {

	[SerializeField]
	private int width;

	[SerializeField]
	private int height;

	[SerializeField]
	private string Randomiser;


	Tile[,] tiles;
	
	private List<Space> spaces = new List<Space>();
	
	[Range(0,100)]
	public int fillPercent;
	
	int[,] map;
	
	void Start() {
		tiles = new Tile[width,height];
		GenerateMap();
	
		RunThroughGraph();
	}
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			spaces = new List<Space>();
			GenerateMap();
			RunThroughGraph();
		}
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
		print(spaces.Count);
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
	
	
	void OnDrawGizmos() {
		if (map != null) {

			// Draw Entire Map
			for (int x = 0; x < width; x ++) {
				for (int y = 0; y < height; y ++) {
					Gizmos.color = (map[x,y] == 1)?Color.black:Color.white;
					Vector3 tmpest = new Vector3(-width/2 + x + .5f, -height/2 + y+.5f,0);
					Gizmos.DrawCube(tmpest,Vector3.one);
				}
			}

			// Draw Outer Tiles. 
			Space tmp = spaces[0];

			foreach (Tile tile in tmp.GetOuterTiles()) {
				float x = tile.GetX();
				float y = tile.GetY();

				Gizmos.color = (tile.IsWall())? Color.black : Color.white;
				Vector3 tmpest = new Vector3 (-width/2 +  x + .5f + 100, -height/2 +  y +.5f + 100,0);
				Gizmos.DrawCube(tmpest, Vector3.one);
		}
	}
	
}
}