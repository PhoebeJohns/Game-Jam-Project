using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    public int floors = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        floors++;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        floors--;
    }
}
