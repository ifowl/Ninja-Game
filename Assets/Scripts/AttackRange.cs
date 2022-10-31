using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private float deathDelay;
    private float deathDelayTimer;
    private bool isKilling = false;
    private GameObject beingKilled;

    void Start()
    {
        deathDelayTimer = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //collider.gameObject.SetActive(false);
        //collider.gameObject.GetComponent<Animator>().SetTrigger("death");
        beingKilled = collider.gameObject;
        beingKilled.GetComponent<Animator>().SetTrigger("death");
        isKilling = true;
    }
    void Update()
    {
        if (isKilling)
        {
            deathDelayTimer += Time.deltaTime;
            if (deathDelayTimer > deathDelay)
            {
                beingKilled.SetActive(false);
                //deathDelayTimer = 0;
                //isKilling = false;
            }
        }
    }
}
