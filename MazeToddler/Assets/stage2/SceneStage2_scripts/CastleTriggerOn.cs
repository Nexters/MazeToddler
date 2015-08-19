using UnityEngine;
using System.Collections;


public class CastleTriggerOn : MonoBehaviour
{
    public GameObject sandcastle_tower_bottom;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
                SpriteRenderer bottom = sandcastle_tower_bottom.GetComponent<SpriteRenderer>();
                bottom.sortingOrder = -1 ;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            SpriteRenderer bottom = sandcastle_tower_bottom.GetComponent<SpriteRenderer>();
            bottom.sortingOrder = 2;
        }
    }
}