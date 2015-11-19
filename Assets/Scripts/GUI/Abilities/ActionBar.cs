using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    [SerializeField]
    private GameObject iceShield;

    [SerializeField]
    private GameObject fireBall;

    [SerializeField]
    private GameObject teleport;

    [SerializeField]
    private GameObject fireNuke;

    GameObject player;

    IceShield shield;
    RangeAttack fire;
    Teleport port;

    PlayerAOEattack nuke;

    void Start()
    {
        player = GameObject.Find("Player");
        iceShield.SetActive(true);
        shield = player.GetComponent<IceShield>();
        fire = player.GetComponent<RangeAttack>();
        port = player.GetComponent<Teleport>();
        nuke = player.GetComponent<PlayerAOEattack>();

    }
    
	
	// Update is called once per frame
	void Update () {

        if (shield.GetShieldOnCooldownStatus())
               HideAbility(iceShield);

        if (!shield.GetShieldOnCooldownStatus())
               ShowAbility(iceShield);
        
        if (fire.GetFireBallCooldownStatus())
            HideAbility(fireBall);

        if (!fire.GetFireBallCooldownStatus())
            ShowAbility(fireBall);

        if (port.GetTeleportCooldownStatus())
            HideAbility(teleport);

        if (!port.GetTeleportCooldownStatus())
            ShowAbility(teleport);

        if (nuke.isNukeOnCooldown())
            HideAbility(fireNuke);

        if (!nuke.isNukeOnCooldown())
            ShowAbility(fireNuke);
    }

    private void HideAbility(GameObject ability)
    {
        ability.SetActive(false);
    }

    private void ShowAbility(GameObject ability)
    {
        ability.SetActive(true);
    }
}
