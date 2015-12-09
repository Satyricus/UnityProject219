using UnityEngine;
using System.Collections;

public class FOWadd : MonoBehaviour {
	public GameObject prefab;
	GameObject FOWHolder;
	int height;
	int width;
	// Use this for initialization
	void Start () {
		height = 16;
		width = 16;
		FOWHolder = new GameObject ("FOWHolder");
		for (float i = 0; i < height; i+=0.32f) {
			for(float j = 0; j < width; j+= 0.32f){
				Vector2 pos = new Vector2 (i,j);
				GameObject g = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
				g.transform.parent = FOWHolder.transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {	
	}
}
