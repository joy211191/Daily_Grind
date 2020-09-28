using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public PlayerController playerController;

    public void TeleportPlayer()
    {
        playerController.NearestCamp();
    }
}
