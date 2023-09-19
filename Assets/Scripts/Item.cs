using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Text _text;
    public RoomInfo _roomInfo { get; private set; }

    public void SetupRoom(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + " P / " + roomInfo.Name;
    }
}
