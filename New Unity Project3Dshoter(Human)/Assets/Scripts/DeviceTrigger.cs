using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _targets;
    public bool _requaireKey;

    private void OnTriggerEnter(Collider other)
    {
        if(_requaireKey && Managares.Inventory._equippedItem != "key")
        {
            return;
        }

        foreach (GameObject target in _targets)
        {
            target.SendMessage("Activate");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in _targets)
        {
            target.SendMessage("Diactivate");
        }
    }
}