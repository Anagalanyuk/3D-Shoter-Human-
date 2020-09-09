using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public float _rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offSet;
    public float _correctVertical;

    private void Start()
    {
        _rotY = _target.eulerAngles.y;
        _offSet = _target.position - transform.position;
    }

    private void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");

        if(horInput != 0)
        {
            _rotY += horInput * _rotSpeed;
        }
        else
        {
            _rotY += Input.GetAxis("Mouse X") * _rotSpeed * 3;
        }

        Quaternion rotation = Quaternion.Euler(0 + _correctVertical, _rotY, 0);
        transform.position = _target.position - (rotation * _offSet);
        transform.LookAt(_target);
    }
}