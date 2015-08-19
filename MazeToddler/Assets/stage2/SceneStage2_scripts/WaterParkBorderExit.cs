using UnityEngine;
using System.Collections;

public class WaterParkBorderExit : MonoBehaviour 
{
    public SpriteRenderer WaterParkBack;
    public SpriteRenderer WaterParkFront;
    public SpriteRenderer WellRoof;
    public SpriteRenderer LiftBack;
    public SpriteRenderer LiftFront;
    public SpriteRenderer Floor;

    public GameObject Boat;
    public CircleCollider2D BoatCircleCol;
    public Vector3 EulerAngleBoat;
    public float RotateSpeed;

    public  EdgeCollider2D WaterParkEdge;
    public  EdgeCollider2D FloorEdge;

    private void OnTriggerEnter2D(Collider2D enterCol)
    {
        if (enterCol.tag == Tags.Player)
        {
            LayerOrder();
            SetCollider();
            RotateBoat();
        }
    }

    private void LayerOrder()
    {
        LiftBack.sortingOrder = -2;
        LiftFront.sortingOrder = 1;
        Floor.sortingOrder = -1;
        WellRoof.sortingOrder = -1;
        WaterParkBack.sortingOrder = -3;
        WaterParkFront.sortingOrder = -4;
    }
    private void SetCollider()
    {
        //WaterParkEdge.enabled = true;
        //FloorEdge.enabled = true;
    }

    private void RotateBoat()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        yield return null;

        BoatCircleCol.enabled = false;

        Quaternion GoalRotation = Quaternion.identity;
        GoalRotation = Quaternion.Euler(EulerAngleBoat);

        while (Boat.transform.rotation != GoalRotation)
        {
            Boat.transform.rotation = Quaternion.Slerp(Boat.transform.rotation, GoalRotation, Time.deltaTime * RotateSpeed);

            yield return null;
        }
    }
}
