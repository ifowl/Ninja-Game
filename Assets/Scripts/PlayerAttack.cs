using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackDelay;
    private Animator anime;
    private float cooldownTimer = Mathf.Infinity;
    private float attackDelayTimer = 0;
    public bool isAttacking;

    [SerializeField] private AudioClip slice;

    private GameObject attackArea = default;

    AttackRange attackRange;

    void Awake()
    {
        attackArea = transform.GetChild(0).gameObject;
        anime = GetComponent<Animator>();
        isAttacking = false;
        attackArea.SetActive(false);
        attackRange = FindObjectOfType<AttackRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X) && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;

        if (isAttacking)
            attackDelayTimer += Time.deltaTime;

        if (attackDelayTimer > attackDelay)
        {
            attackArea.SetActive(true);
        }

        if (isAttacking && cooldownTimer > attackCooldown)
        {
            isAttacking = false;
            attackArea.SetActive(false);
            attackDelayTimer = 0;
        }
        /*
        if (!attackRange.isKilling)
        {
            attackArea.SetActive(false);
        }
        */
    }
    void Attack()
    {
        SoundManager.instance.PlaySound(slice);
        isAttacking = true;
        attackDelayTimer = 0;
        //attackArea.SetActive(true);
        anime.SetTrigger("attack");
        cooldownTimer = 0;
    }
    /*
    void OnTriggerStay2D(Collider2D collider)
    {
        if (isAttacking)
            collider.gameObject.SetActive(false);
    }
    */
    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.SetActive(false);
    }
    */

}
