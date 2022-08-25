using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
//using UnityEngine.Networking;
public class PlayerController : NetworkBehaviour
{
    public Rigidbody rb;
    public float turnSpeed = 1.0f;
    public float rotateInput;
    public float thrust = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        rotateInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * Time.deltaTime * rotateInput * turnSpeed, Space.Self);

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W was pressed");
            rb.AddRelativeForce(0, 0, thrust, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S was pressed");
            rb.AddRelativeForce(0, 0, -thrust, ForceMode.Acceleration);
        }
    }
}
