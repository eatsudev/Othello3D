using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerManager : MonoBehaviourPunCallbacks
{
    public InputField createRoom;
    public InputField joinRoom;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        //PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        RoomOptions options = new RoomOptions();
        Data data = new Data();
        options.MaxPlayers = data.maxPlayerOnRoom;

        PhotonNetwork.CreateRoom(createRoom.text, options);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoom.text);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Game");
    }
}
