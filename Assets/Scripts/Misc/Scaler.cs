using UnityEngine;
using System.Collections;

public class Scaler : MonoBehaviour {


	private int scale;

	// Use this for initialization
	void Start () {
		scale = 1;
	}


	public int GetScale() {
		return this.scale;
	}

	private void increaseLevel() {
		scale++;
	}
}
