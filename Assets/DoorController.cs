using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool open = true;
    private bool openLastFrame;

    public void Awake()
    {
        openLastFrame = open;
    }

    public void Update()
    {
        if (open != openLastFrame)
        {
            if (open) StartCoroutine(OpenDoor());
            else StartCoroutine(CloseDoor());
            openLastFrame = open;
        }
    }

    public IEnumerator CloseDoor()
    {
        for (int i = 0; i < 15; i++)
        {
            transform.position += Vector3.down * 0.333f;
            yield return null;
        }
    }
    public IEnumerator OpenDoor()
    {
        for (int i = 0; i < 15; i++)
        {
            transform.position += Vector3.up * 0.333f;
            yield return null;
        }
    }
}
