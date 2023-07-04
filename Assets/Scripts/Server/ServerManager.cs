using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Servere ba�lan�ld�");
        Debug.Log("Lobiye ba�lan�l�yor");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Lobiye ba�lan�ld�");
        Debug.Log("Odaya ba�lan�l�yor");
        PhotonNetwork.JoinOrCreateRoom("Odaismi", new RoomOptions { MaxPlayers = 3, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Odaya ba�lan�ld�");
        Debug.Log("Karakter olu�turuluyor...");
        PhotonNetwork.Instantiate("Ball", new Vector2(0,0), Quaternion.identity, 0, null);
        PhotonNetwork.Instantiate("star", new Vector2(0, 0), Quaternion.identity, 0, null);
    }

    
}
