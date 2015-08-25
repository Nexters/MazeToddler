using UnityEngine;
using System.Collections;

public class floorDown : MonoBehaviour
{
    public GameObject waterpark_Edge;
    public GameObject waterpark2nd_Edge;
    public GameObject Player;
    public GameObject floor;
    public GameObject Downtrigger;
    public EdgeCollider2D liftmanager;
    public Collider2D UpFloorTrigger;



    private Transform _player;
    private Transform _floor;
   
    private bool UpDown;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        _floor = GameObject.FindGameObjectWithTag(Tags.floortag).transform;
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        //liftmanager.GetComponent<EdgeCollider2D>().enabled = false;
        floor.GetComponent<EdgeCollider2D>().enabled = false;
        Downtrigger.SetActive(false);

        _player.parent = Player.transform;

        waterpark_Edge.SetActive(true);
        this.GetComponent<EdgeCollider2D>().enabled = false;
        
        liftmanager.GetComponent<Animator>().SetBool("Down", false);
        liftmanager.GetComponent<Animator>().SetBool("Up", false);
        UpFloorTrigger.enabled = true;



    }


   
}
