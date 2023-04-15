using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour
{
    public TextMeshPro timerText;
    public Transform wheel;
    public float rotationSpeed;
    public List<SpriteRenderer> coinRenderers;
    public Sprite coinSprite;

    // Start is called before the first frame update
    void Start()
    {
        //Timer
        TimeSpan t = TimeSpan.FromSeconds(GameController.playerTime);
        timerText.text = t.ToString("hh':'mm':'ss'.'fff");
        int loopLimit = 100;
        while (loopLimit > 0 && timerText.text.Length > 8 && (timerText.text[0] == '0' || timerText.text[0] == ':'))
        {
            timerText.text = timerText.text.Substring(1);
            loopLimit--;
        }

        //Coins
        for (int i = 0; i < 3; i++)
        {
            if (GameController.coinsCollected[i])
            {
                coinRenderers[i].sprite = coinSprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        wheel.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
