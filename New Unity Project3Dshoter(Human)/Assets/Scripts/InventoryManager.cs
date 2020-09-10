using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    private Dictionary<string, int> _items;

    public ManagerStatus status { get; private set; }
    public string _equippedItem { get; private set; }

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

    public List<string> GetItemList()
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int GetItemCount(string name)
    {
        int countItem = 0;
        if (_items.ContainsKey(name))
        {
            countItem = _items[name];
        }
        return countItem;
    }

    public bool Eqipuippedtem(string name)
    {
        bool isKey;
        if (_items.ContainsKey(name) && _equippedItem != name)
        {
            _equippedItem = name;
            Debug.Log("Equipped " + name);
            isKey = true;
        }
        else
        {
        _equippedItem = null;
        Debug.Log("Equipped");
        isKey = false;
        }
        return isKey;
    }

    public bool ConsumItem(string name)
    {
       if(_items.ContainsKey(name))
        {
            _items[name]--;
            if(_items[name] == 0)
            {
                _items.Remove(name);
            }
            else
            {
                Debug.Log("Cannot cionsume " + name);
                return false;
            }
        }
        DisplayeItems();
        return false;
    }
}