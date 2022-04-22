using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float _FollowSpeeds = 5f;
    [SerializeField] private Transform _player;

    // Объект камеры
    private Transform _camTransform;

    // Время тряски
    public float _shakeDuration = 0f;

    // Сила тряски. Чем больше, тем больше трясёт
    public float _shakeAmount = 0.1f;
    public float _decreaseFactor = 1.0f;

    Vector3 _pos;

    private void Awake()
    {
        if (!_player)
        {
            _player = FindObjectOfType<Hero>().transform;
        }

        if (!_camTransform)
        {
            _camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        _pos = _camTransform.localPosition;
    }

    //Запускать тряку отсюды)
    public void ShakeCamera()
    {
        _pos = _camTransform.localPosition;
        _shakeDuration = 0.2f;
    }

    void Update()
    {
        Vector3 _newPosition = _player.position;
        _newPosition.z = -10f;
        _newPosition.y = 0.5f;
        transform.position = Vector3.Slerp(transform.position, _newPosition, _FollowSpeeds * Time.deltaTime);

        if (_shakeDuration > 0)
        {
            _camTransform.localPosition = _pos + Random.insideUnitSphere * _shakeAmount;

            _shakeDuration -= Time.deltaTime * _decreaseFactor;
        }
    }
}
