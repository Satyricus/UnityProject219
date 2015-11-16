using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
*    This class is responsible for the GUI panel which displays the stats. 
*/
public class StatsGuiPanel : MonoBehaviour
{
    [SerializeField]
    private Text levelText;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text attackDamageText;

    [SerializeField]
    private Text HasteText;

    [SerializeField]
    private Text xpText;

    [SerializeField]
    private Text neededXPText;

    [SerializeField]
    private GameObject mainPanel; // The entire panel.

    [SerializeField]
    private String inputKey;

    GameObject player;
    PlayerStats stats; 

	// Use this for initialization
	void Start ()
	{
        player = GameObject.Find("Player");
	    stats = player.GetComponent<PlayerStats>();

        mainPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown(inputKey))
            ActivateDeactivatePanel();

	    SetText();
	}

    // sets all of the text variables. 
    private void SetText()
    {
        levelText.text = "Level: " + stats.GetLevel();
        healthText.text = "Health: " + stats.GetCurrentHealth() + " / " + stats.MaxHealth;
        attackDamageText.text = "Attack Damage: " + stats.AttackDamage;
        HasteText.text = "Haste: " + stats.Haste;

        xpText.text = "Current experience: " + stats.GetCurrentXP();
        neededXPText.text = "Needed experience: " + stats.GetNeededXP();

    }

    public void DeactivatePanel()
    {
        mainPanel.SetActive(false);
    }

    // If panel is active, deactivate it. Else activate it. 
    private void ActivateDeactivatePanel()
    {
        if (mainPanel.active) // Disregard the warning, I needed the state. 
        {
            mainPanel.SetActive(false);
        }

        else
        {
            mainPanel.SetActive(true);
        }
    }
 }
