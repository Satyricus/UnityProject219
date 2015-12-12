using UnityEngine;
using System.Collections;

// This class has the responsibility of resizing and placing the action bar into an appropriate size and place. 
public class ActionBarPlacer : MonoBehaviour {

	[SerializeField]
	private GameObject Actionbar;

	[SerializeField]
	private float resizeX;

	[SerializeField]
	private float resizeY;

	[SerializeField]
		private float placementX;

	[SerializeField]
	private float placementY;



	// Use this for initialization
	void Start () {
		ResizeActionBar();
		//PlaceActionBar();
	}
	
	private void ResizeActionBar() {
		var AbTransform = Actionbar.transform;

		AbTransform.localScale = new Vector3(resizeX, resizeY, 1);
	}

	private void PlaceActionBar() {
		var AbTransform = Actionbar.transform;
		AbTransform.position = new Vector3((Screen.width/2) - placementX,(Screen.height/2) - placementY,1);
	}
}
