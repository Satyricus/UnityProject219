using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * 
 * This class is responsible for the rooms or spaces in a cavern. 
 * 
 * I want to run a DFS/BFS in the map to distinguish between the spaces. 
 * Then we want to create a corridor between each space such that You can traverse between them.
 * 
 * 
 */
public class Space {

	public enum Size {
		notWorthIt, verySmall, small, normal, large,VeryLarge
	};

	private Size size;
	private List<Tile> tiles = new List<Tile>();
	private List<Tile> outerTiles = new List<Tile>();
	private bool isConnected;

	public Space() {
		isConnected = false;
	}

	public void addTile(Tile tile) {
		tiles.Add(tile);
	}

	public void addOuterTile(Tile tile) {
		tiles.Add(tile);
		outerTiles.Add(tile);
	}

	public List<Tile> GetOuterTiles() {
		return this.outerTiles;
	}

}
