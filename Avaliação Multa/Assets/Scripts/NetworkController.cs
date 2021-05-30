using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [Header("LOGIN")]
    public GameObject loginPn;
    public InputField playerNameInput;
    string tempPlayerName;
   


    [Header("LOBBY")]
    public GameObject lobbyPn;
    public InputField roomNameInput;
    string tempRoomName;

    [Header("PLAYER")]
    public GameObject playerPUN;
    public GameObject mainCamera;

    
    void Start()
    {
        loginPn.gameObject.SetActive(true);
        lobbyPn.gameObject.SetActive(false);
        tempPlayerName = "Roxas" + Random.Range(3, 99);
        playerNameInput.text = tempPlayerName;

        tempRoomName = "Kimgdom Hearts" + Random.Range(3, 99);
        roomNameInput.text = tempRoomName;
  
    }

    public void Login()
    {
        PhotonNetwork.ConnectUsingSettings();
        if(playerNameInput.text != "")
        {
            PhotonNetwork.NickName = playerNameInput.text;
        }

        else
        {
            PhotonNetwork.NickName = tempPlayerName;
        }
        
        loginPn.gameObject.SetActive(false);
        lobbyPn.gameObject.SetActive(true);
        roomNameInput.text = tempRoomName;
    }

    public void BuscarPartida()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CriarSala()
    {
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomNameInput.text, roomOptions, TypedLobby.Default);
    }


    public override void OnConnected()
    {

        Debug.LogWarning("---------LOGIN-----------");
        Debug.LogWarning("OnConnected");
    }

    public override void OnConnectedToMaster()
    {
        Debug.LogWarning("OnConnectedToMaster");
        Debug.LogWarning("Server: "+PhotonNetwork.CloudRegion);
        Debug.LogWarning("Ping: "+PhotonNetwork.GetPing());
    }

    public override void OnJoinedLobby()
    {
        Debug.LogWarning("-------------LOBBY-------------");
        Debug.LogWarning("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogWarning("OnJoinRandomFailed");
        string sala = "Pato" + Random.Range(111, 9999);
        PhotonNetwork.CreateRoom(sala);
    }

    public override void OnJoinedRoom()
    {
        Debug.LogWarning("OnJoinedRoom");
        Debug.LogWarning("Nome da Sala:" + PhotonNetwork.CurrentRoom.Name);
        Debug.LogWarning("Nome do Player:" + PhotonNetwork.NickName);
        Debug.LogWarning("Players Conectados:" + PhotonNetwork.CurrentRoom.PlayerCount);

        loginPn.gameObject.SetActive(false);
        lobbyPn.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(false);

        PhotonNetwork.Instantiate(playerPUN.name, playerPUN.transform.position, playerPUN.transform.rotation, 0);
    }


    void Update()
    {
        
    }
}
