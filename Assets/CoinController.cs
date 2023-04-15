using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public int coinId;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.coinsCollected[coinId] = true;
        spriteRenderer.enabled = false;
    }
}
