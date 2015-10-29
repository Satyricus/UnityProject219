using UnityEngine;
using System.Collections;

/**
 * This class is responsible for the algorithm that calculates the map.
 * 
 */

public class MapCreator : MonoBehaviour {

	[SerializeField]
	private int width;
	
	[SerializeField]
	private int height;

	[SerializeField]
	private string Randomiser;

	[Range(0,100)]
	public int fillPercent;  // Used for the random algorithm. 

	private Tile[,] tiles;

	private int[,] map;

	public void GenerateMap() {
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

	void CreateTile(int x, int y) {
		bool walled = (map[x,y] == 0)? false : true;
		bool adj = !(GetAdjacentWallCount(x,y) == 0);
		Tile tile = new Tile(x, y, walled, adj);
		tiles[x,y] = tile;
	}

	public int[,] GetMap() {
		return this.map;
	}

	public Tile[,] GetTiles() {
		return this.tiles;
	}

	public int GetWidth() {
		return this.width;
	}

	public int GetHeight() {
		return this.height;
	}


}
