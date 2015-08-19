using UnityEngine;
using System.Collections;

public class keyCastle : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
           // SceneStageMgr2.Instance.AcquiredkeyCastle();
            Destroy(gameObject);
        }
    }
}
