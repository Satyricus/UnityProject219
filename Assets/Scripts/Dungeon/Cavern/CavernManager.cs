using UnityEngine;
using System.Collections;

/**
 * Used to set together the other cavern scripts. 
 */
public class CavernManager : MonoBehaviour {

	private MapGenerator mg;
	private SpaceDFS dfs;
	private MapDrawer drawer;
	private SpawnPlayer playerSpawner;
	private SpawnObjects spawner;

	GameObject player;

	[Range(1,150)]
	public int trashMobsFillPercent;

	
	[Range(1,10)]
	public int chestFillPercent;

	
	[Range(0,100)]
	public int prefabsFillpercent;

	[SerializeField]
	private GameObject[] trashMobs;
	[SerializeField]
	private GameObject[] chests;
	[SerializeField]
	private GameObject[] prefabs; // Stuff.

	GameObject statScaler;
	Scaler scaler;

	private bool hardMode;

	[SerializeField]
	private int hardModeStartLevel;

    GameObject TrashMobHolder;
    GameObject ThingsHolder;


    // Use this for initialization
    void Start ()
    {
        TrashMobHolder = GameObject.Find("TrashMobHolder");
        ThingsHolder = GameObject.Find("ThingsHolder");
        ManagerSetProperties();

		LoadMap ();

		SpawnObjects();


	}

	void Update() {
		/*if(ObjectiveComplete()) {
			if (hardMode)
				scaler.HardMode();

			else
				scaler.increaseLevel();

			LoadMap ();
			SpawnObjects();
			

		}*/
	}

	/*// TODO Implement: creates objectives for clearing the current dungoen. 
	private bool ObjectiveComplete() {
		return false;
	}*/


	// Simply gets the needed references. 
	private void ManagerSetProperties() {
		player = GameObject.Find ("Player");
		mg = GetComponent<MapGenerator>();
		drawer = GetComponent<MapDrawer>();
		playerSpawner = GetComponent<SpawnPlayer>();
		dfs = GetComponent<SpaceDFS>();

		spawner = GetComponent<SpawnObjects>();

		statScaler = GameObject.Find("StatScaler");
		scaler = statScaler.GetComponent<Scaler>();
	}



	/*
	 * Loads and runs through map in order to find the needed information to construct and decide the optimal space.
	 */
	private void LoadMap() {
		mg.GenerateMap();
		drawer.DrawMap();

		dfs.RunThroughGraph();
		dfs.DecideLargestSpace();
	}

	/*
	 * Spawns player, trashmobs, Bosses, Treasure Chests, and prefabs. 
	 */
	private void SpawnObjects() {
		Space largestSpace = dfs.GetLargestSpace();
		playerSpawner.PlayerSpawn(player); // Spawns player.

        // Holder Objects.

        // Parameters int fillPercent, Space largestSpace, GameObject[] things, GameObject player.

        // Spawn trashmobs
        spawner.SpawnThings( trashMobsFillPercent, largestSpace, trashMobs, player, TrashMobHolder);

		// Spawn chests
		spawner.SpawnThings( chestFillPercent, largestSpace, chests, player, ThingsHolder);

		// Spawn prefabs
		spawner.SpawnThings( prefabsFillpercent, largestSpace, prefabs, player, ThingsHolder);

	}

	
	private void SetHardMode() {
		if (Application.loadedLevel == 4) {
			hardMode = true;
			for(int i = 0; i < hardModeStartLevel; i++)
				scaler.increaseLevel();
		}
		
		else 
			hardMode = false;
	}

}
