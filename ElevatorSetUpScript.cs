using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSetUpScript : MonoBehaviour
{
    public GameObject elevator;

    // Start is called before the first frame update
    void Start()
    {
        ElevatorSetUp();
    }

    private void ElevatorSetUp()
    {
        var position = elevator.transform.position;
        var crossPos = new Vector3(20, 0, 0);
        var rotation = transform.rotation;
        Debug.Log(position);
        Instantiate(elevator, position, rotation);
        Instantiate(elevator, -position, rotation);
        Instantiate(elevator, crossPos, rotation);
        Instantiate(elevator, -crossPos, rotation);
    }
}