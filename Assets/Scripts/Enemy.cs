using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private CapsuleCollider2D capCol;
    [SerializeField] private LayerMask playerLayer;
    private float damage = 1;
    private float cooldownTimer = Mathf.Infinity;
    public bool dead = false;

    //References
    private Animator anim;
    private Health playerHealth;
    private PlayerAttack playerAttack;
    private EnemyPatrol enemyPatrol;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        playerAttack = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Atack only when player in sight
        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                if (!playerHealth.dead)
                    anim.SetTrigger("attack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(capCol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(capCol.bounds.size.x * range, capCol.bounds.size.y, capCol.bounds.size.z),
        0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(capCol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(capCol.bounds.size.x * range, capCol.bounds.size.y, capCol.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight() && playerAttack.isAttacking == false)
        {
            if (!playerHealth.dead)
                playerHealth.TakeDamage(damage);
        }
    }
}
