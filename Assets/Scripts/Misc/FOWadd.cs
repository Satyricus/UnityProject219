using UnityEngine;
using System.Collections;

public class FOWadd : MonoBehaviour {
	public GameObject prefab;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		GameObject FOWHolder = new GameObject ("FOWHolder");
		for (float i = -15; i < 15; i+=0.3f) {
				for(float j = -15; j < 15; j+= 0.3f){
				Vector2 pos = new Vector2 (player.transform.position.x + i, player.transform.position.y +j);
				GameObject g = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
				g.transform.parent = FOWHolder.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
