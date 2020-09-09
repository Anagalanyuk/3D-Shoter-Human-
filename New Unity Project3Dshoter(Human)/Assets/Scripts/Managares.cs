using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Playermanager))]
[RequireComponent(typeof(InventoryManager))]

public class Managares : MonoBehaviour
{
    public static Playermanager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Player = GetComponent<Playermanager>();
        Inventory = GetComponent<InventoryManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Inventory);

        StartCoroutine(StartupManagers());


    }
   
    private IEnumerator StartupManagers()
    {
        foreach(IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModuls = _startSequence.Count;
        int numReady = 0;

        while(numReady < numModuls)
        {
            int lastRedy = numReady;
            numReady = 0;
        }


    }
}
