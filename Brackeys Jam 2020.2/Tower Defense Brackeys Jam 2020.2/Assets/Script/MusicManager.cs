using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    new AudioSource audio;
    public AudioClip[] clips;
    int selectedTrack = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
    }

    void Update()
    {
        if (!audio.isPlaying)
        {
            OnSoundEnd();
        }
    }

    void OnSoundEnd()
    {
        selectedTrack++;
        if (selectedTrack > clips.Length - 1) selectedTrack = 0;
        audio.clip = clips[selectedTrack];
        audio.Play();
    }
}
