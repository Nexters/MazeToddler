using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    private Transform _transform;
    private Animator _animator;
    private PlayerItem _cPlayerItem;

    void Awake()
    {
        _transform = transform;
        _animator = GetComponent<Animator>();
        _cPlayerItem = FindObjectOfType(typeof(PlayerItem)) as PlayerItem;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            if (SceneStageMgr0.Instance.PlayerHasShell())
            {
                Destroy(gameObject);
                _cPlayerItem.playerShell.SetActive(false);
            }
            else
                _animator.SetBool("isContact", true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _animator.SetBool("isContact", false);
    }
}
