using UnityEngine;
using System.Collections;


/*
 * This class has the responsibility of drawing the map.
 * 
 */ 
public class MapDrawer : MonoBehaviour {



	private int height;
	private int width;

	private int[,] map;

	[SerializeField]
	private GameObject[] floorTiles;

	[SerializeField]
	private GameObject[] wallTiles;

	private GameObject ground;
	private GameObject wall;

	MapCreator mc; // MC!! This one passes on the needed values such as hight, width etc. 

	void Start() {

		mc = GetComponent<MapCreator>();
		map = mc.GetMap();
		width = mc.GetWidth();
		height = mc.GetHeight();
	}

	// Randomises the tiles which we draw each time. 
	private void setWallAndFloorTiles() {
		ground = floorTiles[UnityEngine.Random.Range(0, floorTiles.Length)];
		wall = wallTiles[UnityEngine.Random.Range(0, wallTiles.Length)];
	}

	/**
	 * Draw the map. 
	 * Our tile sprites are 32-bit so 32 pixels far. 
	 */
	public void DrawMap() {
		setWallAndFloorTiles();
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				// Is the tile ground? Wall?
				GameObject tile =(map[x,y] == 0)? ground : wall;
				Vector3 position = new Vector3(x*0.32f, y*0.32f,0);
				
				// Instansiates a gameObject. Need to find a way to hide it in the hirearchy as child to another game object. 
				Instantiate(tile,position, Quaternion.identity);
				
			}
		}
	}
}
