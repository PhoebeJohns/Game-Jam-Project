using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Transform cameraTransform;
    public Toggle speedrunToggle;

    // Start is called before the first frame update
    void Start()
    {
        speedrunToggle.isOn = GameController.speedrunMode;
        GameController.speedrunMode = speedrunToggle.isOn;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.Rotate(Vector3.forward, Time.deltaTime * 5);
    }

    public void ToggleSpeedrunMode()
    {
        GameController.speedrunMode = !GameController.speedrunMode;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
