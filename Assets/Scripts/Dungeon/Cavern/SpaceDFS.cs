﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceDFS : MonoBehaviour {

	MapCreator mc;

	Tile[,] tiles;
	int width;
	int height;

	private List<Space> spaces = new List<Space>();


	void Start() {
		mc = GetComponent<MapCreator>();

		width = mc.GetWidth();
		height = mc.GetHeight();

		tiles = mc.GetTiles();
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

}
