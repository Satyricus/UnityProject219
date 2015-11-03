using System;
using UnityEngine;
using System.Collections;

public class HearthStone : MonoBehaviour
{


    [SerializeField] private String InputKey;

	
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(InputKey))
            Application.LoadLevel(2);
	}
}
