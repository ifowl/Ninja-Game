using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private float deathDelay;
    private bool isKilling = false;
    private GameObject beingKilled;

    void OnTriggerEnter2D(Collider2D collider)
    {
        beingKilled = collider.gameObject;
        beingKilled.GetComponent<Animator>().SetTrigger("death");
        isKilling = true;
    }
    void Update()
    {
        if (isKilling)
        {
            Destroy(beingKilled, deathDelay);
        }
    }
}
