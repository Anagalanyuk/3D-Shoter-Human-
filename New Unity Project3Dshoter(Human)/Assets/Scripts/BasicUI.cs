using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    private void OnGUI()
    {
        int _posX = 10;
        int _posY = 10;
        int _width = 100;
        int _height = 30;
        int _buffer = 10;

        List<string> itemList = new List<string>(Managares.Inventory.GetItemList());
        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(_posX, _posY, _width, _height), "No items");
        }

        foreach (string item in itemList)
        {
            int count = Managares.Inventory.GetItemCount(item);
            string path = "Icons/" + item;
            Texture2D image = Resources.Load<Texture2D>(item);
            GUI.Box(new Rect(_posX, _posY, _width, _height), new GUIContent("(" + count + ")", image));
            _posX += _width + _buffer;

        }

        string equipped = Managares.Inventory._equippedItem;
        if (equipped != null)
        {
            _posX = Screen.width - (_width + _buffer);
            Texture2D image = Resources.Load(equipped) as Texture2D;
            GUI.Box(new Rect(_posX, _posY, _width, _height), new GUIContent(equipped, image));
        }

        _posX = 10;
        _posY += _height + _buffer;

        foreach (string item in itemList)
        {
            if (GUI.Button(new Rect(_posX, _posY, _width, _height), "equip " + item))
            {
                Managares.Inventory.Eqipuippedtem(item);
            }
            _posX += _width + _buffer;
        }
    }
}
