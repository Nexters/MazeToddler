using UnityEngine;
using System.Collections;

public class WaterParkBorderEnter : MonoBehaviour 
{
    public SpriteRenderer WaterParkBack;
    public SpriteRenderer WaterParkFront;
    public SpriteRenderer WellRoof;
    public SpriteRenderer LiftBack;
    public SpriteRenderer LiftFront;
    public SpriteRenderer Floor;

    public EdgeCollider2D WaterParkEdge;
    public EdgeCollider2D FloorEdge;

    private void OnTriggerEnter2D(Collider2D enterCol)
    {
        if (enterCol.tag == Tags.Player)
        {
            SetCollider();
            LayerOrder();
        }
    }

    private void SetCollider()
    {
        //WaterParkEdge.enabled = false;
        //FloorEdge.enabled = false;
    }

    private void LayerOrder()
    {
        LiftBack.sortingOrder = 3;
        LiftFront.sortingOrder = 5;
        Floor.sortingOrder = 4;
        WaterParkBack.sortingOrder = 2;
        WaterParkFront.sortingOrder = 2;
        WellRoof.sortingOrder = 3;
    }
}
