using UnityEngine;
using System.Collections;

public class Ride : MonoBehaviour
{
    public GameObject Boat;
    private Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
    }

    private void OnTriggerStay2D(Collider2D enterCol)
    {
        if (enterCol == null)
            return;

        if(enterCol.gameObject.tag == Tags.Player)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D info = Physics2D.Raycast(mousePos, Vector2.zero);

                if (info.collider == null)
                    return;
                if (info.collider.tag == Tags.Boat)
                {
                    StartCoroutine(Jump());
                }
            }
        }
    }
    private IEnumerator Jump()
    {
        yield return null;

        Boat.GetComponent<EdgeCollider2D>().enabled = true;
        _player.GetComponent<playerCtrl>().canMove = false;

        _player.parent = transform;
        _player.GetComponent<CircleCollider2D>().enabled = false;

        _player.GetComponent<playerCtrl>().Move(transform.position);

        float remain = (transform.position - _player.position).sqrMagnitude;

        while (remain * remain > 0.1f)
        {

            remain = (transform.position - _player.position).sqrMagnitude;
            yield return null;
        }

        _player.GetComponent<playerCtrl>().Stop = true;

        GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(1.0f);

        _player.GetComponent<CircleCollider2D>().enabled = true;
        _player.parent = Boat.transform;

        Boat.GetComponent<CircleCollider2D>().enabled = true;
        Boat.GetComponent<Rigidbody2D>().gravityScale = 2.0f;
    }
}
