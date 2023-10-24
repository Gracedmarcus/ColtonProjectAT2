using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updated 10 oct by Joshua T

public class Movement : MonoBehaviour
{
    private float horizontal, vertical;
    CharacterController playerControl;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<CharacterController>(out playerControl);
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetAxis("Horizontal") != 0)
        {
            playerControl.Move(transform.right * horizontal / 50);
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            playerControl.Move(transform.forward * vertical / 50);
        }
    }
}
