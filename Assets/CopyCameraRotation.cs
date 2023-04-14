using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyCameraRotation : MonoBehaviour
{
    public CameraController camera;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = camera.transform.rotation;
    }
}
