using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawmScript : MonoBehaviour
{
    public GameObject enemy;
    private Coroutine _mCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        _mCoroutine ??= StartCoroutine(nameof(SpawnEach));
    }

    public IEnumerator SpawnEach()
    {
        yield return new WaitForSeconds(3);
        SpawnEnemy();
        _mCoroutine = null;
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, enemy.transform.position, enemy.transform.rotation);
    }
}
