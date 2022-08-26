using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class bulletSpawner : NetworkBehaviour
{
    public GameObject bulletprefab;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnBulletServer();

            Debug.Log("Bullet Spawned");
        }

    }

    /*void SpawnBullet()
    {
        if (IsServer)
            SpawnBulletServer();

        else
            SpawnBulletServerRPC();
    }*/

    void SpawnBulletServer()
    {
        GameObject go = Instantiate(bulletprefab, transform.position, transform.rotation);

        go.GetComponent<NetworkObject>().Spawn();
    }
    //[ServerRpc]

    /*void SpawnBulletServerRPC()
    {
        SpawnBulletServer();
    }*/
    
}
    

   

 


    
