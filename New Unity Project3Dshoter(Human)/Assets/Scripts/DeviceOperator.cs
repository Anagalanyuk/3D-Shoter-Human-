using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float _radius = 1.5f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Collider[] hitColiders = Physics.OverlapSphere(transform.position, _radius);
            foreach (Collider hitColider in hitColiders)
            {

                Vector3 direction = hitColider.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.5f)
                {
                    hitColider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}