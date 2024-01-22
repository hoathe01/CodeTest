using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public float movingSpeed;
    public Coroutine elevatorCoroutine;
    public float maxHeight = 10;

    private float _height;

    void Update()
    {
        if (_height >= maxHeight)
        {
            elevatorCoroutine ??= StartCoroutine(nameof(ElevatorCoroutine));
        }
        else
        {
            var speedCal = movingSpeed * Time.deltaTime;
            _height += Mathf.Abs(speedCal);
            transform.Translate(Vector3.up * speedCal);
        }
    }

    public IEnumerator ElevatorCoroutine()
    {
        yield return new WaitForSeconds(3);
        movingSpeed = -movingSpeed;
        _height = 0;
        elevatorCoroutine = null;
    }
}