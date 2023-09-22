using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public UIManager _UI;

    private void Update()
    {
        Data data = new Data();
        if(PhotonNetwork.CurrentRoom.PlayerCount == data.maxPlayerOnRoom)
        {
            _UI.SetStatus("Game Starting...");
            StartCoroutine(_UI.DisableStatusUI(10));
        }
        else
        {
            _UI.SetStatus("Waiting for players...");
        }
    }
}
