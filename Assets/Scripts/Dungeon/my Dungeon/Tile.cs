using UnityEngine;
using System.Collections;

public class Tile {

	private float x;
	private float y;
	private bool isWall;
	private bool isAdjacentToWall;

	// Used for traversing the map. 
	private bool isDiscovered;

	public Tile (float x, float y, bool isWall, bool isAdjToWall) {
		this.x = x;
		this.y = y;
		this.isWall = isWall;
		this.isAdjacentToWall = isAdjToWall;
		this.isDiscovered = false;
	}

	public float GetX() {
		return this.x;
	}

	public float GetY() {
		return this.y;
	}

	public void DiscoverNode() {
		this.isDiscovered = true;
	}
	
	public bool IsDiscovered() {
		return this.isDiscovered;
	}



	public bool IsWall() {
		return this.isWall;
	}

	public bool IsAdjacentToWall() {
		return this.isAdjacentToWall;
	}

}
