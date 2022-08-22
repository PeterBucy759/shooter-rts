using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
//using UnityEngine.Networking;

public class Move : NetworkBehaviour
{
    public float thrust = 10;
    public float torque = 1;
    public Rigidbody rb;

    void Start()
    {
        //hello whaaaaaats! up

        rb = GetComponent<Rigidbody>();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }

    // Update is called once per frame
    void Update()   
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W was pressed");
            rb.AddRelativeForce(0, 0, thrust, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A was pressed");
            rb.AddTorque(0, -torque, 0, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S was pressed");
            rb.AddRelativeForce(0, 0, -thrust, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D was pressed");
            rb.AddTorque(0, torque, 0, ForceMode.Force);
        }

    }
}
