using System;
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

	
	[Range(1,5)]
	public int bossFillpercent;

	public bool debug;

	
	[Range(0,100)]
	public int prefabsFillpercent;

	[SerializeField]
	private GameObject[] trashMobs;
	[SerializeField]
	private GameObject[] chests;
	[SerializeField]
	private GameObject[] prefabs; // Decoration or whatever else you want spawned.

    [SerializeField]
    private GameObject[] bosses;

    GameObject statScaler;
	Scaler scaler;

	private bool hardMode;

	[SerializeField]
	private int hardModeStartLevel;

    GameObject TrashMobHolder;
    GameObject ThingsHolder;
    GameObject BossHolder;
    GameObject TileHolder;

    // Use this to make sure the game knows when you're allowed to kill objects. 
    private bool bossKillable; // Starts as false.


	private void initiate() {
	
		ManagerSetProperties();

	}

    // Use this for initialization
    void Start ()
    {

		TrashMobHolder = GameObject.Find("TrashMobHolder");
		ThingsHolder = GameObject.Find("ThingsHolder");
		TileHolder = GameObject.Find("TileHolder");
		
		BossHolder =  GameObject.Find("BossHolder");

		player = GameObject.Find ("Player");
		statScaler = GameObject.Find("StatScaler");



		initiate();

		LoadMap ();
		
		SpawnObjects();

    }

	void Update() {


		if(ObjectiveComplete()) {
            DestroyMap(); 


		/*	if (hardMode){
				scaler.HardMode();
			}
			else {
				scaler.increaseLevel();
			}*/



			initiate ();

            LoadMap ();

			SpawnObjects();

		}
	}

    private void DestroyMap()
    {
        if (TileHolder.transform.childCount > 0)
        {
			Transform TileTransform = TileHolder.transform;

			foreach(Transform child in TileTransform) {
				Destroy (child.gameObject);
			}
		
		} 

		if (ThingsHolder.transform.childCount > 0)
		{
			Transform ThingTransform = ThingsHolder.transform;
			
			foreach(Transform child in ThingTransform) {
				Destroy (child.gameObject);
			}
			
		} 


    }



    // True if trashmobs and the boss is dead. 
	private bool ObjectiveComplete()
	{
	    return (TrashMobsAreDead());
	}

    public bool TrashMobsAreDead()
    {
		return (TrashMobHolder.transform.childCount == 0);
    }


    public bool BossIsDead()
    {
        return (BossHolder.transform.childCount == 0);
    }




    // Simply gets the needed references. 
    private void ManagerSetProperties() {
		mg = GetComponent<MapGenerator>();
		drawer = GetComponent<MapDrawer>();
		playerSpawner = GetComponent<SpawnPlayer>();
		dfs = GetComponent<SpaceDFS>();

		spawner = GetComponent<SpawnObjects>();

		scaler = statScaler.GetComponent<Scaler>();
	}



	/*
	 * Loads and runs through map in order to find the needed information to construct and decide the optimal space.
	 */
	private void LoadMap() {
		if (debug) {
			print ("Loading map!");
		}

		mg.Awake();
		mg.GenerateMap();
		drawer.DrawMap();
		
		dfs.RunThroughGraph();
		dfs.DecideLargestSpace();

		GameObject.Find ("FOGManager").GetComponent<FOWadd>().loadFOW();

	}

	/*
	 * Spawns player, trashmobs, Bosses, Treasure Chests, and prefabs. 
	 */
	private void SpawnObjects() {
        bossKillable = false;

        Space largestSpace = dfs.GetLargestSpace();
		playerSpawner.PlayerSpawn(player); // Spawns player.

        // Holder Objects.

        // Parameters int fillPercent, Space largestSpace, GameObject[] things, GameObject player.

        // Spawn trashmobs
        spawner.SpawnThings( trashMobsFillPercent, largestSpace, trashMobs, player, TrashMobHolder);

		// Spawn chests
		spawner.SpawnThings( chestFillPercent, largestSpace, chests, player, ThingsHolder);

		// Spawn prefabs

		largestSpace.GetSouthernTile();


		spawner.SpawnThings( prefabsFillpercent, largestSpace, prefabs, player, ThingsHolder);

        spawner.SpawnThings(bossFillpercent , largestSpace, bosses, player, TrashMobHolder);

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

	public GameObject GetTileHolder() {
		return this.TileHolder;
	}

}
