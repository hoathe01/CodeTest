using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    private GameObject _playerObject;
    private Text _healthText;
    private float _playerHealth;

    private void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _healthText = GetComponent<Text>();
    }

    void Update()
    {
        _playerHealth = _playerObject.GetComponent<Moving>().playerHealth;
        _healthText.text = $"Health: {_playerHealth}";
    }
}
