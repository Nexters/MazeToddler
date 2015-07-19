using UnityEngine;
using System.Collections;

public class DoorEntrance : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        print(string.Format("collider Tag = {0}", collider.transform.tag));
        if (collider.transform.tag == "Player")
        {
            GameObject doorExit = GameObject.Find("Door_Exit");
            Transform warpPos = doorExit.transform.FindChild("warpPos");
            Vector3 exitPos = warpPos.position;
            collider.transform.localPosition = exitPos;
        }
       
    }
}
