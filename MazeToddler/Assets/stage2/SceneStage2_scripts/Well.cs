using UnityEngine;
using System.Collections;

public class Well : MonoBehaviour
{
    public GameObject Bucket;
    public Animator RopeLeft;
    public Animator RopeRight;

    private bool _bBucketAcquired = false;
    private bool _bRasie = false;

    private void OnTriggerStay2D(Collider2D enterColl)
    {
        if (_bBucketAcquired)
            return;

        if (enterColl.gameObject.tag == Tags.Player)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D info = Physics2D.Raycast(mousePos, Vector2.zero);

                if (info.collider == null)
                    return;
                if (info.collider.tag == Tags.Well)
                {
                    info.collider.enabled = false;

                    StartCoroutine(Raise());
                }


                if (_bRasie && info.collider.tag == Tags.Bucket)
                {
                    Bucket.SetActive(false);

                    SceneStageMgr2.Instance.GetPlayerItem().GetItem(PlayerItem2.E_ITEM_LIST.BUCKET);

                    _bBucketAcquired = true;
                }
            }
        }
    }

    private IEnumerator Raise()
    {
        yield return null;

        Bucket.GetComponent<Animator>().enabled = true;
        RopeLeft.enabled = true;
        RopeRight.enabled = true;

        yield return new WaitForSeconds(2.2f);

        RopeLeft.enabled = false;
        RopeRight.enabled = false;

        yield return new WaitForSeconds(0.8f);

        _bRasie = true;
    }
}
