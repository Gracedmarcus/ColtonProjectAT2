using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Updated 19 Oct by Joshua T

public class Interactables : MonoBehaviour
{
    public List<GameObject> list;
    public Text goal;
    public GameObject goalObj;
    private int i;
    private Camera cam;
    public AudioClip interactSound, toiletSound, bedSound, tableSound;
    public static AudioSource audioSource;

    void Start()
    {
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
        goalObj.gameObject.SetActive(false);
    }

    void Update()
    {

            if (goalObj.gameObject.activeSelf == true)
            {
                StartCoroutine(nameof(Enumerator));
            }
            if (Input.GetButtonDown("Interact"))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 2f))
            {
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.gameObject.CompareTag("Interactable"))
                {
                    if (hit.collider.gameObject.name == "PFB_DoorDouble")
                    {
                        hit.collider.gameObject.SendMessage("Interacted", hit);
                    }
                    else
                    {
                        Interacted(hit.collider.gameObject);
                    }
                }
            }
        }
        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
            Debug.Log("Game Quit");
        }
    }

    IEnumerator Enumerator()
    {
        yield return new WaitForSeconds(3);
        goalObj.gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 2f, Color.blue);
        }
    }

    public void Interacted(GameObject hit)
    {
        for(i=0; i<list.Count; i++)
        {
            if (list[i].name == hit.name)
            {
                goalObj.gameObject.SetActive(true);
                break;
            }
        }
        switch (i)
        {
            case 0:
                {
                    goal.text = "Your dog could sleep on it.";
                    audioSource.PlayOneShot(bedSound);
                    i = 0;
                    break;
                }
            case 1:
                {
                    goal.text = "Ah, Your porcelain throne, sire.";
                    audioSource.PlayOneShot(toiletSound);
                    i = 0;
                    break;
                }
            case 2:
                {
                    goal.text = "This is a table, but I digress.";
                    audioSource.PlayOneShot(tableSound);
                    i = 0;
                    break;
                }
        }
    }
}
