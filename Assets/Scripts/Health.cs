using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private Animator anim;
    public bool dead = false;

    private bool gameover;
    private float gameoverTimer = 0;
    private float gameoverDelay = 3;
    [SerializeField] private GameObject deathUI;

    [SerializeField] private AudioClip hurt;

    void Awake()
    {
        gameover = false;
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        deathUI.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hurt);
            anim.SetTrigger("hurt");
        } else
        {
            if (!gameover)
            {
                SoundManager.instance.PlaySound(hurt);
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().dead = true;
                dead = true;
                gameover = true;
                deathUI.SetActive(true);
            }
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
        if (gameover)
        {
            gameoverTimer += Time.deltaTime;
            if (gameoverTimer > gameoverDelay)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    
}
