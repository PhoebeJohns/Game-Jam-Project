using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool speedrunMode;
    public static float playerTime;
    public static bool[] coinsCollected = new bool[3];

    public List<Image> coinImages;
}
