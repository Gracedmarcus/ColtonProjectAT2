using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updated 19 Oct by Joshua T

public class Interact : MonoBehaviour
{
    private Camera cam;
    public GameObject eventSys;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 2f))
            {
                Debug.Log(hit.collider.gameObject);
                if(hit.collider.gameObject.CompareTag("Interactable"))
                {
                   //Interacted(hit.collider.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 2f, Color.blue);
        }
    }
}
