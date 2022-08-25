using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class bulletSpawner : NetworkBehaviour
{
    public GameObject bulletprefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnBullet();

            Debug.Log("Bullet Spawned");
        }

    }
    void SpawnBullet()
    {
        if (IsServer)
            SpawnBulletServer();
        else
            SpawnBulletServerRPC();
    }
    void SpawnBulletServer()
    {
        GameObject go = Instantiate(bulletprefab, NetworkManager.Singleton.LocalClient.PlayerObject.transform.position, NetworkManager.Singleton.LocalClient.PlayerObject.transform.rotation);

        go.GetComponent<NetworkObject>().Spawn();
    }
    [ServerRpc]

    void SpawnBulletServerRPC()
    {
        SpawnBulletServer();
    }
    
}
    

   

 


    
