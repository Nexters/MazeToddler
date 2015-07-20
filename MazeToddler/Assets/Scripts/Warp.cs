using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {
    private GameObject Fader;

    public GameObject WarpDestination;

    void Awake()
    {
        Fader = GameObject.Find("Fader") as GameObject;
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            float fadeTime = Fader.GetComponent<Fader>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);

            Vector3 exitPos = WarpDestination.transform.position;
            collider.transform.localPosition = new Vector3 (exitPos.x, exitPos.y, -1);

            Fader.GetComponent<Fader>().BeginFade(-1);
        }
       
    }
}
