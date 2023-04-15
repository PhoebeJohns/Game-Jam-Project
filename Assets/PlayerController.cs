using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public FloorDetection floorDetector;
    public CameraController cameraController;
    public Camera mainCamera;
    public SpriteRenderer spriteRenderer;

    public CheckpointController currentCheckpoint;
    private bool hasCheckpoint = true;

    public float velocityX;
    public float velocityY;

    private float targetVelocityX = 0;

    public float moveSpeed = 2;
    public float moveSpeedLerp = 10;

    public float jumpVelocity = 5;
    public float gravity = 15;
    public float floatyGravity = 10;
    public bool floaty = false;
    public float terminalVelocity = 45;

    public bool movementIsLocked = false;
    public bool dead = false;

    public int gravityMode = 0; // 0 - down; 1 - right; 2 - up; 3 - left;
    public int GravityModeAngle => gravityMode * 90;
    private int lastGravityMode = 0;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            StartCoroutine(Respawn(false));
        }
    }

    public void GameEnd()
    {
        StartCoroutine(Respawn(true));
    }

    public IEnumerator Respawn(bool gameEnd)
    {
        dead = true;
        rb.velocity = Vector3.zero;
        for (int i = 0; i < 75; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - 0.0166f);
            yield return new WaitForSeconds(0.01f);
        }
        if (!gameEnd)
        {
            dead = false;
            spriteRenderer.color = new Color(1, 1, 1, 1);
            transform.parent = currentCheckpoint.transform;
            transform.localPosition = new Vector3(0.25f, -0.5f, 0);
            transform.parent = null;
            gravityMode = currentCheckpoint.gravityMode;
        }
        else
        {
            Debug.Log("Game End!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Gravity
        if (gravityMode != lastGravityMode && !dead)
        {
            transform.rotation = Quaternion.Euler(0, 0, GravityModeAngle);
            cameraController.targetCameraRotation = GravityModeAngle;
            lastGravityMode = gravityMode;
        }

        if (!movementIsLocked)
        {
            if (!dead)
            {
                rb.isKinematic = false;

                //X velocity
                targetVelocityX = 0;

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    targetVelocityX--;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
                {
                    targetVelocityX++;
                }

                targetVelocityX *= moveSpeed;

                velocityX = Mathf.Lerp(velocityX, targetVelocityX, Time.deltaTime * moveSpeedLerp);

                //Y velocity
                velocityY -= (floaty ? floatyGravity : gravity) * Time.deltaTime;

                bool canJump = floorDetector.floors > 0;

                if (canJump)
                {
                    if (velocityY <= 0)
                    {
                        velocityY = -0.5f;
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        floaty = true;
                        velocityY = jumpVelocity;
                    }
                }

                if (floaty && Input.GetKeyUp(KeyCode.Space))
                {
                    velocityY *= 0.5f;
                    floaty = false;
                }

                if (Input.GetKeyUp(KeyCode.Space) || velocityY < jumpVelocity / 5)
                {
                    floaty = false;
                }

                if (velocityY < -terminalVelocity) velocityY = -terminalVelocity;

                //Update rigidbody
                rb.velocity = GetRotatedVector(new Vector2(velocityX, velocityY));
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;

            if (Input.GetKeyDown(KeyCode.A))
            {
                gravityMode--;
                if (gravityMode < 0) gravityMode = 3;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                gravityMode++;
                if (gravityMode > 3) gravityMode = 0;
            }
        }
    }

    public Vector2 GetRotatedVector(Vector2 v)
    {
        return gravityMode switch
        {
            0 => v,
            1 => new Vector2(-v.y, v.x),
            2 => new Vector2(-v.x, -v.y),
            3 => new Vector2(v.y, -v.x),
            _ => v
        };
    }

    public void SetCurrentCheckpoint(CheckpointController cp)
    {
        if (hasCheckpoint) currentCheckpoint.checkpointActive = false;
        cp.checkpointActive = true;
        hasCheckpoint = true;
        currentCheckpoint = cp;
    }
}
