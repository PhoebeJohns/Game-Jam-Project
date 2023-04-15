using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public List<SpriteRenderer> disables;
    public GameController gameController;
    public Animator coinAnim;

    public int coinId;

    private void Awake()
    {
        coinAnim.StopPlayback();
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 45);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.coinsCollected[coinId] = true;
        GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(CollectAnimation());
        gameController.coinImages[coinId].sprite = disables[0].sprite;
        gameController.coinImages[coinId].color = new Color(1, 1, 1, 1);
        coinAnim.SetBool("coinanim", true);
    }

    public IEnumerator CollectAnimation()
    {
        for (int i = 0; i < 50; i++)
        {
            foreach (SpriteRenderer ren in disables)
            {
                ren.color = new Color(ren.color.r, ren.color.g, ren.color.b, (50 - i)/(float)51);
            }
            transform.localScale += Vector3.one * 0.03f;
            yield return new WaitForSeconds(0.01f);
        }
        coinAnim.SetBool("coinanim", false);
    }
}
