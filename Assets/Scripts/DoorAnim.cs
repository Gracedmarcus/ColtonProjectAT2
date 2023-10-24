using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updated 19 Oct by Joshua T
public class DoorAnim : MonoBehaviour
{
    private bool open;
    public Animation anim;
    public AudioClip doorsound;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = Interactables.audioSource;
        open = false;
        anim = GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    public void Interacted(RaycastHit hit)
    {
        if(anim.isPlaying)
        {
            return;
        }
        else if(!open)
        {
            anim.Play("Open");
            audiosource.PlayOneShot(doorsound);
            open = true;
        }
        else if (open)
        {
            anim.Play("Closed");
            audiosource.PlayOneShot(doorsound);
            open = false;
        }
    }
}
