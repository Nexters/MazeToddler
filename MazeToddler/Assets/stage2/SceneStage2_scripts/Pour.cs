using UnityEngine;
using System.Collections;

public class Pour : MonoBehaviour 
{
    public GameObject PourObj;
    public Transform Key;
    public Vector3 ArrivePos;
    public Vector3 CamPos;

    private bool _bPourComplete = false;

    private void OnTriggerStay2D(Collider2D enterColl)
    {
        if (!Camera.main.GetComponent<mainCam>().SubCam)
        {
            Camera.main.GetComponent<mainCam>().SubCam = true;
            StopCoroutine(camBack());
        }

        if (Camera.main.orthographicSize < 7.0f)
            Camera.main.orthographicSize += Time.deltaTime * 1.5f;

        Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, CamPos, Time.deltaTime * 2.0f);

        if (_bPourComplete)
            return;

        if (!SceneStageMgr2.Instance.GetPlayerItem().IsHasItem(PlayerItem2.E_ITEM_LIST.BUCKET))
            return;

        if (enterColl.gameObject.tag == Tags.Player)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D info = Physics2D.Raycast(mousePos, Vector2.zero);

                if (info.collider == null)
                    return;
               

                if (info.collider.tag == Tags.Pour)
                {
                    _bPourComplete = true;

                    SceneStageMgr2.Instance.GetPlayerItem().UseItem(PlayerItem2.E_ITEM_LIST.BUCKET);
                    StartCoroutine(start());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D exitColl)
    {
        Camera.main.GetComponent<mainCam>().SubCam = false;
        StartCoroutine(camBack());
    }

    private IEnumerator camBack()
    {
        yield return null;

        while (Camera.main.orthographicSize > 5.0f)
        {
            Camera.main.orthographicSize -= Time.deltaTime * 4.0f;

            yield return null;
        }
    }

    private IEnumerator start()
    {
        yield return null;

        PourObj.SetActive(true);

        yield return new WaitForSeconds(0.25f);

        StartCoroutine(Float());
    }

    private IEnumerator Float()
    {
        yield return null;

        float remain = (ArrivePos - Key.position).sqrMagnitude;

        while (remain * remain > 0.01f)
        {
            Key.position = Vector3.Slerp(Key.position, ArrivePos, 0.2f);

            remain = (ArrivePos - Key.position).sqrMagnitude;
            yield return null;
        }
    }
}
