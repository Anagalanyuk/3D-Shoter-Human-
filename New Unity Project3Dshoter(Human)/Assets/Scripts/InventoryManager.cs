using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
   public ManagerStatus status { get; private set; }

    public void Startup()
    {
        Debug.Log("inventory manager started");
        status = ManagerStatus.Started;
    }
}
