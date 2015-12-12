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
	public string pauseKey;
	public GameObject pauseImage;
	GameObject player;
	GameObject pObj;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	    pause = false;

	}
	void Update(){
		if (Input.GetKeyDown (pauseKey) || Input.GetKeyDown (KeyCode.Joystick1Button7)){
			if(Time.timeScale > 0.5){
				pObj = Instantiate(pauseImage,player.transform.position,Quaternion.identity) as GameObject;
				Time.timeScale = 0;
			}
			else{
				Destroy(pObj);
				Time.timeScale = 1;
			}
		}
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
