using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody body;
    public float upForce = 10;
    PhotonView photonView;


    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            photonView.RPC(nameof(Jump),RpcTarget.All);
        }
    }


    public void ApplyForceByNormal(Vector3 normal)
    {

    }

    public void MoveToPosition(Vector3 position)
    {

    }

    [PunRPC]
    public void Jump()
    {
        body.velocity = Vector3.zero;
        body.AddForce(Vector3.up * upForce, ForceMode.Impulse);
    }



}
