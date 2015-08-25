using UnityEngine;
using System.Collections;

public class BoatArrive : MonoBehaviour 
{
    public GameObject Lander;
    public GameObject WaterParkEdge;
    public GameObject WaterSlideEdge;
    private Transform _transformPlayer;

    private void Awake()
    {
        _transformPlayer = GameObject.FindGameObjectWithTag(Tags.Player).transform;
    }

    private void OnCollisionEnter2D(Collision2D enterCol)
    {
        if(enterCol.transform.tag == Tags.Boat)
        {
            StartCoroutine(Arrive());
        }

    }
    private IEnumerator Arrive()
    {
        yield return new WaitForSeconds(2.0f);

        _transformPlayer.parent = Lander.transform;
        StartCoroutine(Landing());
    }

    private IEnumerator Landing()
    {
        yield return null;

        _transformPlayer.parent = Lander.transform;
        _transformPlayer.GetComponent<CircleCollider2D>().enabled = false;
        _transformPlayer.GetComponent<playerCtrl>().Move(Lander.transform.position);

        float remain = (Lander.transform.position - _transformPlayer.position).sqrMagnitude;

        while (remain * remain > 0.01f)
        {
            remain = (Lander.transform.position - _transformPlayer.position).sqrMagnitude;
            yield return null;
        }

        _transformPlayer.GetComponent<playerCtrl>().Stop = true;

        Lander.GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(1.0f);

        _transformPlayer.GetComponent<CircleCollider2D>().enabled = true;
        _transformPlayer.parent = GameObject.Find("Player").transform;
        _transformPlayer.GetComponent<playerCtrl>().canMove = true;
        WaterParkEdge.SetActive(true);
        WaterSlideEdge.SetActive(false);
    }
}
