using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _isGround = false;
    [SerializeField] private float _speed = 0;
    private Rigidbody _rb;
    private Vector3 _moveDirection;
    private Vector3 _StartPos;

    public static event EventHandler PickUpGarbage;

    void Start()
    {
        _StartPos = transform.position;
        _rb = GetComponent<Rigidbody>();
        Restarter.Restart += Restarter_Restart;
    }

    private void Restarter_Restart(object sender, EventArgs e)
    {
        transform.position = _StartPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGround = true;

        ICanPickUp icanPickUp = collision.gameObject.GetComponent<ICanPickUp>();

        if (icanPickUp != null)
        {
            collision.gameObject.transform.parent = gameObject.transform;
            collision.gameObject.transform.localPosition = new Vector3
                (collision.gameObject.transform.localPosition.x,
                0,
                collision.gameObject.transform.localPosition.z);
            PickUpGarbage?.Invoke(this, null);
        }
    }

    public void Move(Vector3 direction)
    {
        if (!_isGround)
            return;

        if (direction.magnitude > 30)
        {
            _moveDirection.x = direction.normalized.x;
            _moveDirection.z = direction.normalized.y;
            _moveDirection.y = 0f;

            
            Quaternion newRotation = Quaternion.LookRotation(_moveDirection);
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 360f, 0f) * Time.deltaTime);
            _rb.MoveRotation(newRotation * deltaRotation);
            
           
            _rb.velocity = _moveDirection * _speed;
        }
    }
}
