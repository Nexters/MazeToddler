using UnityEngine;
using System.Collections;

public class CastleTrigger : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;
    public GameObject sandcastle_tower_bottom;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            if (On.activeSelf)
            {
                On.SetActive(false);
                Off.SetActive(true);
                SpriteRenderer bottom = sandcastle_tower_bottom.GetComponent<SpriteRenderer>();
                bottom.sortingOrder = 2;
            }
           /* if (Off.activeSelf)
            {
                On.SetActive(true);
                Off.SetActive(false);
                SpriteRenderer bottom = sandcastle_tower_bottom.GetComponent<SpriteRenderer>();
                bottom.sortingOrder = -1;
            }*/
        }
    }
}
