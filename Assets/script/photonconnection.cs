using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class photonconnection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster()
    {
        print(" conectao ");
        PhotonNetwork.JoinLobby(); 
    }
    public override void OnJoinedLobby()
    {
        print(" ha entrado al lobyy ");
        PhotonNetwork.JoinOrCreateRoom("Test", newRoom(),null); 
    }
    public override void OnJoinedRoom()
    {
        print("ya entró"); 
        PhotonNetwork.Instantiate("Square", new Vector2(0,0), Quaternion.identity);
        
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("valió verga" + message);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("valió verga" + message);
    }
    RoomOptions newRoom()
    {
        RoomOptions roomOpc = new RoomOptions();
        roomOpc.MaxPlayers = 10; 
        roomOpc.IsOpen = true;
        roomOpc.IsVisible = true;
        return roomOpc;
    }
}
