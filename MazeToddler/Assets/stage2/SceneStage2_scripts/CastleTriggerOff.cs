using UnityEngine;
using System.Collections;

public class CastleTriggerOff : MonoBehaviour
{
    public GameObject On;
    public GameObject sandcastle_tower_bottom;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            On.SetActive(true);
            gameObject.SetActive(false);
            SpriteRenderer bottom = sandcastle_tower_bottom.GetComponent<SpriteRenderer>();
            bottom.sortingOrder = -1;
        }
    }
}
