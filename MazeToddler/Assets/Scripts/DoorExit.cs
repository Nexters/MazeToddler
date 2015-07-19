using UnityEngine;
using System.Collections;

public class DoorExit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        print(string.Format("collider Tag = {0}", collider.transform.tag));
        if (collider.transform.tag == "Player")
        {
            GameObject doorEntrance = GameObject.Find("Door_Entrance");
            Transform warpPos = doorEntrance.transform.FindChild("warpPos");
            Vector3 exitPos = warpPos.position;
            collider.transform.localPosition = exitPos;
        }

    }
}
