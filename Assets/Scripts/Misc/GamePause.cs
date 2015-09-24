using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Responsible for pausing the game. 
 * All movable gameObjects (enemies, players, allies etc..) will have an instance to this. 
 * 
 * True if the game is paused, else false.
 */
  
public class GamePause : MonoBehaviour {
     
    private bool pause;

	// Use this for initialization
	void Start () {
	    pause = false;

	}

	public bool GetPausStatus() {
		return pause;
	}
	
    public void UnPause() {
        pause = false;
		// TODO DISABLE PAUSE MENU.
    }
	// 
    public void Pause() {
        pause = true;
		// TODO SHOW PAUSE MENU.
    }

	public void UnlockCharacters() {
		pause = false;
	}
	
	public void LockCharacters() {
		pause = true;
	}


}
