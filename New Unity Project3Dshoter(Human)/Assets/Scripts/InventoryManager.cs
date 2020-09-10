using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private Dictionary<string, int> _items;

    public void Startup()
    {
        Debug.Log("inventory manager started");
        _items = new Dictionary<string, int>();
        status = ManagerStatus.Started;
    }

    private void DisplayeItems()
    {
        string displayItm = "Items: ";

        foreach (KeyValuePair<string, int> item in _items)
        {
            displayItm += item.Key + "(" + item.Value + ") ";
        }
        Debug.Log(displayItm);
    }

    public void AddItem(string name)
    {
        if (_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else
        {
            _items[name] = 1;
        }

        DisplayeItems();
    }
}
