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
                if (hit.collider != false)
                {
                    if (hit.collider.gameObject.CompareTag("Interactable"))
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
        yield return new WaitForSeconds(4);
        goalObj.gameObject.SetActive(false);
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
                    StartCoroutine(nameof(Enumerator));
                    i = 0;
                    break;
                }
            case 1:
                {
                    goal.text = "Ah, Your porcelain throne, sire.";
                    audioSource.PlayOneShot(toiletSound);
                    StartCoroutine(nameof(Enumerator));
                    i = 0;
                    break;
                }
            case 2:
                {
                    goal.text = "This is a table, but I digress.";
                    audioSource.PlayOneShot(tableSound);
                    StartCoroutine(nameof(Enumerator));
                    i = 0;
                    break;
                }
            case 3:
                {
                    if (hit.TryGetComponent<DoorAnim>(out DoorAnim dooranim))
                    {                     
                        dooranim.Interacted();
                        StartCoroutine(nameof(Enumerator));
                        i = 0;
                    }
                    break;
                }
        }
    }
}
