using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	Vector2 screenPos;

	private int healthbarWidth = 40;				// Display max health.
	private int currentHealthWidth;					// Display health the mob is currently at.

	GameObject parent;
	EnemyStats stats;

	private int maxHealth;
	private int currentHealth;


	// Use this for initialization
	void Start () {
		currentHealthWidth = healthbarWidth;
		parent = transform.parent.gameObject;
		stats = parent.GetComponent<EnemyStats>();
		maxHealth = stats.getHealth();
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.parent.position;
		currentHealth = stats.getHealth ();
		//print (stats.getHealth ());
		//print ("max: " + maxHealth);
		//print ("cur: " + currentHealth);
		if (currentHealth < 0) {
			currentHealth = 0;
		}
		if (currentHealth >= maxHealth) {
			currentHealth = maxHealth;
			return;
		}

		//print ("healthBatWidth: " + healthbarWidth + ", currentHealth: " + currentHealth);
		//print (currentHealthWidth);

		//currentHealthWidth = (int)(((float)currentHealth / 100) * healthbarWidth);
		currentHealthWidth = (int)((float)currentHealth / (float)maxHealth * healthbarWidth);
	}

	void OnGUI() {
		screenPos = Camera.main.WorldToScreenPoint (transform.parent.position);
		// Screen.height - (blah) because GUI and camera use different coordinate systems.
		DrawQuad (new Rect ((screenPos.x - healthbarWidth/2), (Screen.height - screenPos.y - 40), healthbarWidth, 8), Color.grey);
		if (currentHealthWidth >= 8) {	// For now, because of texture borders, these cannot be smaller then 8x8 pixels.
			DrawQuad (new Rect ((screenPos.x - healthbarWidth / 2), (Screen.height - screenPos.y - 40), currentHealthWidth, 8), Color.red);
		}
	}

	void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D (1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
