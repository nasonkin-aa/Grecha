using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _pos;
    void Update()
    {
        _pos = _player.position;
        _pos.z = -10f;
        _pos.y = 1;
        transform.position = Vector3.Lerp(transform.position , _pos, Time.deltaTime);
    }

    private void Awake()
    {
        if (!_player)
        {
            _player = FindObjectOfType<Hero>().transform;
        }
    }
}
