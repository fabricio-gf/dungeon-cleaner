using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource = null;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMute(bool mute)
    {
        audioSource.mute = mute;
    }

}
