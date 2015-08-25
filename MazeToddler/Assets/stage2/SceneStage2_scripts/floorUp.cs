using UnityEngine;
using System.Collections;

public class floorUp : MonoBehaviour
{

    public GameObject waterpark2nd_Edge;
    public GameObject Player;
    public GameObject floor;
    public GameObject Downtrigger;
    public EdgeCollider2D liftmanager;
    public GameObject level;


    private Transform _player;
    private Transform _floor;
    private Animator _animator;



    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        _floor = GameObject.FindGameObjectWithTag(Tags.floortag).transform;
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        liftmanager.GetComponent<EdgeCollider2D>().enabled = false;
        floor.GetComponent<EdgeCollider2D>().enabled = false;
        Downtrigger.SetActive(true);

        _player.parent = Player.transform;

        waterpark2nd_Edge.SetActive(true);
        this.GetComponent<EdgeCollider2D>().enabled = false;
        level.SetActive(true);



    }
}
