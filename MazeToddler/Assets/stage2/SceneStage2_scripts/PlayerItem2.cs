using UnityEngine;
using System.Collections;

public class PlayerItem2 : MonoBehaviour {
    public GameObject playerkeyCastle;
    public GameObject playerkeyWaterpark;

    public bool playerGotkeyCastle = false;
    public bool playerGotkeyWaterpark = false;

    void Awake()
    {
        playerGotkeyCastle = false;
        playerGotkeyWaterpark = false;
        playerkeyCastle.SetActive(playerGotkeyCastle);
        playerkeyWaterpark.SetActive(playerGotkeyWaterpark);
    }

    public void PlayerGotkeyCastle()
    {
        playerGotkeyCastle = true;
        playerkeyCastle.SetActive(playerGotkeyCastle);
    }

    public void PlayerGotkeyWaterpark()
    {
        playerGotkeyWaterpark = true;
        playerkeyWaterpark.SetActive(playerGotkeyWaterpark);
    }
}

