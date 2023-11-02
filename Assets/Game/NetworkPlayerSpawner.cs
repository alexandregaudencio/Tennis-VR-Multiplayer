using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform player1SpawnPoint;
    [SerializeField] private Transform player2SpawnPoint;

    private GameObject spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        SetStartupLocation();

    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
        base.OnLeftRoom();
    }


    private void SetStartupLocation()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetworkPlayer", player1SpawnPoint.position, player1SpawnPoint.rotation);
        }
        else
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetworkPlayer", player2SpawnPoint.position, player2SpawnPoint.rotation);

        }
    }

}
