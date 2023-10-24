using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Updated 19 Oct by Joshua T

public class Interactables : MonoBehaviour
{
    public List<GameObject> list;
    public Text goal, goal1, goal2, goal3;
    public GameObject goalObj;
    private int i;
    private Camera cam;
    public AudioClip interactSound, toiletSound, bedSound, tableSound;
    public static AudioSource audioSource;

    void Start()
    {
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
        goal1.text = "Find Bed";
        goal2.text = "Find Toilet";
        goal3.text = "Find Table";
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
        yield return new WaitForSeconds(1);
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
                    goal.text = "This is a bed. You do lazy business on it.";
                    audioSource.PlayOneShot(bedSound);
                    goal1.text = "Found it!";
                    break;
                }
            case 1:
                {
                    goal.text = "This is a toilet. You stinky business on it.";
                    audioSource.PlayOneShot(toiletSound);
                    goal2.text = "Found it!";
                    break;
                }
            case 2:
                {
                    goal.text = "This is a table. You do tasty business on it.";
                    audioSource.PlayOneShot(tableSound);
                    goal3.text = "Found it!";
                    break;
                }
        }
    }
}
