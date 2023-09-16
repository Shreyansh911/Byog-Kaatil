using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSys : MonoBehaviour
{
    public AudioSource ConversationAudio;
    public AudioClip[] clip;
    public float volume = 0.5f;

    public void Awake()
    {
        ConversationAudio = GetComponent<AudioSource>();
    }

    public void Start()
    {
            InitateConversation();
    }
    public void InitateConversation()
    {
        ConversationAudio.PlayOneShot(clip[0],volume);
        Debug.Log(clip[0].length);

        
    }

   

}
