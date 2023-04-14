using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public PlayerController player;
    public Camera cam;
    public Vector3 offset;
    public float cameraLerpSpeed = 9;
    public float cameraZoomSpeed = 5;
    public float targetCameraRotation = 0;

    public bool isZoomedOut = false;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (!isZoomedOut)
        {
            Vector2 rotatedOffsetFlat = player.GetRotatedVector(new Vector2(offset.x, offset.y));
            Vector3 rotatedOffset = new Vector3(rotatedOffsetFlat.x, rotatedOffsetFlat.y, offset.z);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 8, cameraZoomSpeed * 2 * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + rotatedOffset, cameraLerpSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetCameraRotation), cameraLerpSpeed * Time.deltaTime);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 100, cameraZoomSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -10), cameraLerpSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetCameraRotation), cameraLerpSpeed * Time.deltaTime);
        }
    }
}
