using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private PlayerController player;
    private SpriteRenderer spriteRenderer;
    public bool checkpointActive = false;
    private bool activeLastFrame = false;
    public int gravityMode = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.SetCurrentCheckpoint(this);
    }

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointActive != activeLastFrame)
        {
            spriteRenderer.color = new Color(1, 1, 1, checkpointActive ? 1 : (float)80/255);
            activeLastFrame = checkpointActive;
        }
    }
}
