using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{

    public class Player : NetworkBehaviour
    {
        [SerializeField] private Vector3 movement = new Vector3();

        // Update is called once per frame
        [Client]
        void Update()
        {
            movement.x = 0;
            movement.z = 0;

            if (!hasAuthority) return;
            

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
                movement.z = 5 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movement.x = -5 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movement.z = -5 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movement.x = 5 * Time.deltaTime;
            }
            CmdMove();
        }


        [Command]
        private void CmdMove()
        {
            RpcMove();
        }

        [ClientRpc]
        private void RpcMove()
        {
            transform.Translate(movement);
        }
    }
}