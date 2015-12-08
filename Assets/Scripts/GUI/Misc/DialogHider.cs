using UnityEngine;
using System.Collections;

public class DialogHider : MonoBehaviour {

	[SerializeField]
	private GameObject Dialog;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {

		if (Application.loadedLevel != 2)
			Dialog.SetActive(false);

		else 
			Dialog.SetActive(true);
	
	}
}
