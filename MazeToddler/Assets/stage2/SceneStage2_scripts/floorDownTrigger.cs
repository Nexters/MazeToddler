using UnityEngine;
using System.Collections;

public class floorDownTrigger : MonoBehaviour
{

    public GameObject waterpark2nd_Edge;
    public GameObject floor;
    public EdgeCollider2D liftmanager;
   
    
    void OnTriggerEnter2D(Collider2D col)
    {


        waterpark2nd_Edge.SetActive(false);

        liftmanager.GetComponent<EdgeCollider2D>().enabled = true;
        floor.GetComponent<EdgeCollider2D>().enabled = true;    
        




    }
}
