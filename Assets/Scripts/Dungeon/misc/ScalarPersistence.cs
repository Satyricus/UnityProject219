using UnityEngine;
using System.Collections;

public class ScalarPersistence : MonoBehaviour {

	[SerializeField]
	GameObject StatScalar;

	// Starts before Start.
	void Awake()
	{

		// There is no stat scaler
		if (GameObject.Find("StatScaler") == null) {

			GameObject StatScaler  = (GameObject) Instantiate(StatScalar, new Vector3(0, 0, 0), Quaternion.identity);
		}	
			
			DontDestroyOnLoad(gameObject);
			DontDestroyOnLoad(GameObject.Find ("StatScaler"));
			
		}

	
	void Update()
	{
		if (Application.loadedLevel == 1 || Application.loadedLevel == 0)
			Destroy(GameObject.Find("StatScaler"));
			//Destroy (gameObject); TODO Test
	}
}
