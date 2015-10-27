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

	public void increaseLevel() {
		scale++;
	}

	public void HardMode() {
		scale += 5;
	}

}
