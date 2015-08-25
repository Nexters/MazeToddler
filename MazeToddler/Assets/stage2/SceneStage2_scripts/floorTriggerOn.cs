using UnityEngine;
using System.Collections;

public class floorTriggerOn : MonoBehaviour
{

    public GameObject floor;
    public GameObject waterpark_Edge;
    public GameObject waterpark2nd_Edge;
    public GameObject level;

    public Collider2D UpFloorTrigger;
    public Collider2D DownFloorTrigger;
    public GameObject floorDownTrigger;

    private Transform _player;
    private Transform _floor;
    private Animator _animator;
    public bool UpDown;






    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        _floor = GameObject.FindGameObjectWithTag(Tags.floortag).transform;
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag.Equals("Player"))
        {
            EdgeCollider2D _floorBorder = floor.GetComponent<EdgeCollider2D>();
            _floorBorder.enabled = true;

            _floor.parent = transform;
            _player.parent = transform;

            GetComponent<Animator>().SetBool("Up", true);
            GetComponent<Animator>().enabled = true;

            _floor.GetComponent<EdgeCollider2D>().enabled = true;
            _player.parent = floor.transform;


            floor.GetComponent<EdgeCollider2D>().enabled = true;


            waterpark_Edge.SetActive(false);
            waterpark2nd_Edge.SetActive(false);
            
            




        }
        if (level.active == true)
        {
            EdgeCollider2D _floorBorder = floor.GetComponent<EdgeCollider2D>();
            _floorBorder.enabled = true;
            GetComponent<Animator>().SetBool("Down", true);

            _floor.parent = transform;
            _player.parent = transform;

            
            //GetComponent<Animator>().enabled = true;

            //_floor.GetComponent<EdgeCollider2D>().enabled = true;
            _player.parent = floor.transform;


            floor.GetComponent<EdgeCollider2D>().enabled = true;


            waterpark_Edge.SetActive(false);
            waterpark2nd_Edge.SetActive(false);
            DownFloorTrigger.enabled = true;
            level.SetActive(false);

        }

    }



}



/*트리거가 플레이어를 만났을때 - 워터파크2층켜고,플레이어 패어런츠바꿔주고, 애니메이션 up끄고
           if (UpFloorTrigger.tag == "floortag" && Enter == true)
           {
               GetComponent<Animator>().SetBool("Up", false);
               _waterpark2nd_Edge.enabled = true;
               _floorBorder.enabled = false;
               Enter = false;
           }

           if (UpFloorTrigger.tag == "floortag" && Enter == false)
           {
               GetComponent<Animator>().SetBool("Down", true);
               _waterpark2nd_Edge.enabled = false;
           }*/


