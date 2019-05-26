using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource = null;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMute()
    {
        audioSource.mute = !audioSource.mute;
    }

}
