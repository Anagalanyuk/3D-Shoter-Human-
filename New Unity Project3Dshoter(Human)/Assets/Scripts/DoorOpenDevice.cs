using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 _dPos;
    private bool _open;

    public void Operate()
    {
        Debug.Log("Botton");
        if (_open)
        {
            Vector3 pos = transform.position - _dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + _dPos;
            transform.position = pos;
        }
        _open = !_open;
    }
}
