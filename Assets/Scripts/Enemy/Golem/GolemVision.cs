using UnityEngine;
using System.Collections;

/*
* Responsible for finding the target of golem if golem sees the Player.
*/
public class GolemVision : MonoBehaviour
{

    private GameObject target;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            target = GameObject.Find("Player");

    }

    void OnTriggerExit2D(Collider2D other)
    {
        // TODO May give a bug as tags are unstable:
        if (other.CompareTag("Player"))
            target = null;
    }

    public GameObject GetTarget()
    {
        return target;
    }
}
