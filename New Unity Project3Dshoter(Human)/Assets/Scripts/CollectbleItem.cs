﻿using UnityEngine;

public class CollectbleItem : MonoBehaviour
{
    [SerializeField] private string _itemName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(_itemName);

        Managares.Inventory.AddItem(_itemName);

        Destroy(this.gameObject);
    }
}