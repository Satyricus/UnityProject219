using UnityEngine;
using System.Collections;

/*
* This class is responsible for creating a player, transferring said player through the scenes and also killing the player object on game over. 
*/

public class PersistentObject : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int x;  // Player spawn x coordinate.

    [SerializeField]
    private int y;  // Player spawn y coordinate.

    // Starts before Start.
    void Awake()
    {
        // In case there is no player.
        GameObject playerParentObject = GameObject.Find("MovableCharacters");

        if (playerParentObject.transform.childCount == 0)
        {
            GameObject playa = GameObject.Find("player");

            GameObject Player  = (GameObject) Instantiate(player, new Vector3(x, y, 0), Quaternion.identity);
            
            Player.transform.SetParent(playerParentObject.transform);

            DontDestroyOnLoad(playerParentObject);
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(Player);

            Player.name = "Player";
        }
    }

    void Update()
    {
        if (Application.loadedLevel == 1)
            Destroy(GameObject.Find("Player"));
    }

}
