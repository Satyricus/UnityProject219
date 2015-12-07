using System;
using UnityEngine;
using System.Collections;

public class Scaler : MonoBehaviour {


	private int scale;
	private bool hardMode;

    public bool debug;

	// Use this for initialization
	void Start () {
		scale = 1;
	}


	public int GetScale() {
		return this.scale;
	}

	public void increaseLevel() {
		scale++;
        if (debug)
            print(scale);
	}

	public void HardMode() {
		hardMode = true;
		scale += 5;

	    if (debug)
	        print(scale);
	}

	public void NormalMode() {
		if (hardMode)
			scale -= 5;

		hardMode = false;
		if (debug)
			print(scale);
	}

}
