using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement = default;

    private Vector3 _startPosTouch;
    private Vector3 _direction;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosTouch = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            _direction = Input.mousePosition -_startPosTouch;
            _playerMovement.Move(_direction);
        }
    }
}
