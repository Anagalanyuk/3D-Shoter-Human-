using UnityEngine;

public class Playermanager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int _helth { get; private set; }
    public int _maxHelth { get; private set; }

    public void Startup ()
    {
        Debug.Log("Player mnager starting...");

        _helth = 50;
        _maxHelth = 100;

        status = ManagerStatus.Started;
    }

    public void ChangeHalth(int value)
    {
        if(_helth > _maxHelth)
        {
            _helth = _maxHelth;
        }
        else if (_helth < 0)
        {
            _helth = 0;
        }

        Debug.Log("Helth:" + _helth + "/" + _maxHelth);
    }
}