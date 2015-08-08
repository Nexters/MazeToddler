using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    private PlayerItem _cPlayerItem;

    void Awake()
    {
        _cPlayerItem = FindObjectOfType(typeof(PlayerItem)) as PlayerItem;
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals ("Player")) {
            if (SceneStageMgr0.Instance.PlayerHasHammer())
            {
                _cPlayerItem.playerHammer.SetActive(false);
                Destroy(gameObject);
            }
		}
	}
}
