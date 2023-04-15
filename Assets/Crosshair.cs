using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Camera mainCamera;
    public List<SpriteRenderer> renderers;
    public float rotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += Time.deltaTime * -25;
        transform.rotation = Quaternion.Euler(0, 0, rotation);

        foreach (SpriteRenderer ren in renderers)
        {
            ren.color = new Color(1, 1, 1, Mathf.Max(0, mainCamera.orthographicSize * 3 - 100)/ 255);
        }
    }
}
