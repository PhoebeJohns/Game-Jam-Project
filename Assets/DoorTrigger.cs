using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public DoorController doorLink;
    public bool openDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        doorLink.open = openDoor;
    }
}
