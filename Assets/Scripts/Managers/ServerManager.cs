using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerManager : MonoBehaviourPunCallbacks
{
    public Text roomPin;

    [Header("Required Components")]
    public Item itemPrefab;
    public Transform content;

    private List<Item> items = new List<Item>();

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(roomPin.text, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Create Room success");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.LogError("Create Room failed: " + message);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        foreach (RoomInfo item in roomList)
        {
            if(item.RemovedFromList)
            {
                int index = items.FindIndex( x => x._roomInfo.Name == item.Name );
                if(index != -1)
                {
                    Destroy(items[index].gameObject);
                    items.RemoveAt(index);
                }
            }
            else
            {
                Item _list = Instantiate(itemPrefab, content);
                if(_list != null)
                {
                    _list.SetupRoom(item);
                    items.Add(_list);
                }
            }
        }
    }
}
