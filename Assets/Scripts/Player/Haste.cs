using UnityEngine;
using System.Collections;

public class Haste : MonoBehaviour {
	PlayerMovement pMovement;
	public string useKey;
	public float hasteCooldown;
	private float hasteStart;
	public float hasteUseTime;
	private int defaultSpeed;
	// Use this for initialization
	void Start () {
		pMovement = GetComponent<PlayerMovement> ();
		defaultSpeed = pMovement.speed;
		hasteStart = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (useKey) || Input.GetKeyDown (KeyCode.Joystick1Button8)) && Time.time > hasteStart + hasteCooldown) {
			useHaste();
			hasteStart = Time.time;
		}
		else if (Time.time > hasteStart + hasteUseTime)
			pMovement.setMovementSpeed (defaultSpeed);

	}
	private void useHaste(){
		pMovement.setMovementSpeed (defaultSpeed+1);
	}


	public bool GetHasteCooldownStatus()
	{
		return (Time.time < hasteStart + hasteCooldown);
	}
}
