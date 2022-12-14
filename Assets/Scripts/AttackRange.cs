using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private float deathDelay;
    //private bool isKilling = false;
    private GameObject beingKilled;

    [SerializeField] private GameObject winManager;

    [SerializeField] private AudioClip cut;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetType() == typeof(BoxCollider2D))
        {
            SoundManager.instance.PlaySound(cut);
            beingKilled = collider.gameObject;
            beingKilled.GetComponent<Enemy>().enabled = false;
            beingKilled.GetComponent<Animator>().SetTrigger("death");
            //isKilling = true;
            Destroy(beingKilled, deathDelay);
            if (beingKilled.GetComponent<Enemy>().dead == false)
                winManager.GetComponent<WinGame>().KillDragon();
            beingKilled.GetComponent<Enemy>().dead = true;
        }
    }
}
