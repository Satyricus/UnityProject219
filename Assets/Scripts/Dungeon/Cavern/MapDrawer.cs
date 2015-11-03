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

	MapGenerator mg; //  This one passes on the needed values such as hight, width etc. 

    GameObject tileHolder;

	private void MapDrawerSetProperties() {
        tileHolder = GameObject.Find("TileHolder");
		mg = GetComponent<MapGenerator>();
		map = mg.GetMap();
		width = mg.GetWidth();
		height = mg.GetHeight();
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
		MapDrawerSetProperties();
		setWallAndFloorTiles();
		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				// Is the tile ground? Wall?
				GameObject tile =(map[x,y] == 0)? ground : wall;
				Vector3 position = new Vector3(x*0.32f, y*0.32f,0);
				
				// Instansiates a gameObject.  TODO find a way to hide it in the hirearchy as child to another game object. 
				GameObject mapTile = (GameObject) Instantiate(tile,position, Quaternion.identity);

                mapTile.transform.SetParent(tileHolder.transform);
				
			}
		}
	}
}
