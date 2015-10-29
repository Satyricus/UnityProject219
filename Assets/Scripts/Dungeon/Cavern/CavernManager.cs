using UnityEngine;
using System.Collections;

/**
 * Used to set together the other cavern scripts. 
 */
public class CavernManager : MonoBehaviour {

	private MapCreator mc;

	private SpaceDFS dfs;

	MapDrawer drawer;

	// Use this for initialization
	void Start () {

		mc = GetComponent<MapCreator>();
		dfs = GetComponent<SpaceDFS>();
		drawer = GetComponent<MapDrawer>();

		LoadMap();
	
	}

	private void LoadMap() {
		mc.GenerateMap();
		drawer.DrawMap();
	}

}
