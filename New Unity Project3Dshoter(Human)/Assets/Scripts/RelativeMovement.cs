using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public float _rotSpeed = 15.0f;
    public float _moveSped = 6.0f;
    public float _jumpSpeed = 15.0f;
    public float _gravity = -9.8f;
    public float _terminalVelocity = -10f;
    public float _minFall = -1.5f;
    public float pushForce = 3.0f;

    private ControllerColliderHit _contact;
    private Animator _animator;
    private float _vertSpeed;

    private CharacterController _charcontroller;
    private void Start()
    {
        _charcontroller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _vertSpeed = _minFall;
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * _moveSped;
            movement.z = vertInput * _moveSped;
            movement = Vector3.ClampMagnitude(movement, _moveSped);

            Quaternion tmp = _target.rotation;
            _target.eulerAngles = new Vector3(0, _target.eulerAngles.y, 0);
            movement = _target.TransformDirection(movement);
            _target.rotation = tmp;
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, _rotSpeed * Time.deltaTime);
        }

        _animator.SetFloat("speed", movement.sqrMagnitude);


        bool hitGround = false;
        RaycastHit hit;
        if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_charcontroller.height + _charcontroller.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }

        if (hitGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = _jumpSpeed;
            }
            else
            {
                _vertSpeed = _minFall;
                _animator.SetBool("jump", false);
            }
        }
        else
        {
            _vertSpeed += _gravity * 5 * Time.deltaTime;
            if (_vertSpeed < _terminalVelocity)
            {
                _vertSpeed = _terminalVelocity;
            }

            if (_contact != null)
            {
                _animator.SetBool("jump", true);
            }

            if (_charcontroller.isGrounded)
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    movement = _contact.normal * _moveSped;
                }
                else
                {
                    movement += _contact.normal * _moveSped;
                }
            }
        }

        movement.y = _vertSpeed;

        movement *= Time.deltaTime;
        _charcontroller.Move(movement);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;

        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }
}
