using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Watcher : MonoBehaviour
{
    private GameObject _myPlayer;
    private Coroutine _mCoroutine;
    private Vector3 _target;
    public float speed;

    void Start()
    {
        _myPlayer = GameObject.FindGameObjectWithTag("Player");
        _target = _myPlayer.transform.position;
        transform.LookAt(_target);
    }

    void Update()
    {
        var playerPosition = _myPlayer.transform.position;
        _target = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
        _mCoroutine ??= StartCoroutine(nameof(LockTarget), _target);
        transform.Translate(transform.forward.normalized * (speed * Time.deltaTime), Space.World);
        DestroyBaseOnCollision();
    }

    public IEnumerator LockTarget(Vector3 target)
    {
        yield return new WaitForSeconds(1);
        transform.LookAt(target);
        _mCoroutine = null;
    }

    private void DestroyBaseOnCollision()
    {
        var distance = Vector3.Distance(_myPlayer.transform.position, transform.position);
        if (distance <= 1)
        {
            Destroy(gameObject);
            _myPlayer.GetComponent<Moving>().playerHealth -= 25;
        }
    }
}