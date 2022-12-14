using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinGame : MonoBehaviour
{
    [SerializeField] private int numOfDragons;
    private int killedDragons;

    private bool winGame;
    private float winTimer = 0;
    private float winDelay = 5;
    [SerializeField] private GameObject winUI;
    [SerializeField] private TMP_Text killedText;

    private void Awake()
    {
        killedDragons = 0;
        winGame = false;
        winUI.SetActive(false);
    }
    public void KillDragon()
    {
        ++killedDragons;
        killedText.text = "Dragons Killed: " + killedDragons.ToString();
        if (killedDragons >= numOfDragons)
        {
            winGame = true;
            winUI.SetActive(true);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (winGame)
        {
            winTimer += Time.deltaTime;
            if (winTimer > winDelay)
                SceneManager.LoadScene(1);
        }
    }
}
