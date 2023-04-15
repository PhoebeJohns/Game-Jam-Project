using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalController : MonoBehaviour
{
    private PlayerController player;
    private CameraController camera;

    public Sprite faceSprite;
    public Sprite interactSprite;
    public SpriteRenderer spriteRenderer;

    public bool playerIsInside = false;
    public bool zoomedOut = false;

    public void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    public void Update()
    {
        if (playerIsInside)// && (zoomedOut || Mathf.Abs(player.GravityModeAngle - transform.rotation.z) < 45))
        {
            spriteRenderer.sprite = interactSprite;
            if (Input.GetKeyDown(KeyCode.E))
            {
                zoomedOut = !zoomedOut;
                player.movementIsLocked = !player.movementIsLocked;
                player.velocityX = 0;
                camera.isZoomedOut = !camera.isZoomedOut;
            }
        }
        else
        {
            spriteRenderer.sprite = faceSprite;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsInside = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        playerIsInside = false;
    }
}
