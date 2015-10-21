using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * 
 * This class is responsible for the rooms or spaces in a cavern. 
 * 
 * I want to run a DFS/BFS in the map to distinguish between the spaces. 
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
	private Tile southernTile;
	private bool isConnected;

	public Space() {
		isConnected = false;
		southernTile = null;
	}

	public void addTile(Tile tile) {
		tiles.Add(tile);

		if (southernTile == null)
			southernTile = tile;

		if (southernTile.GetY () > tile.GetY ())
			southernTile = tile;
	}

	public void addOuterTile(Tile tile) {
		tiles.Add(tile);
		outerTiles.Add(tile);
	}

	public List<Tile> GetOuterTiles() {
		return this.outerTiles;
	}

	public List<Tile> GetTiles() {
		return this.tiles;
	}

	public int NumberOfTiles() {
		return this.tiles.Count;
	}

	public Tile GetSouthernTile() {
		return this.southernTile;
	}
}
