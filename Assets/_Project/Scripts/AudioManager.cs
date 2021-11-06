using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    [SerializeField] private AudioSource audioSource;
    private int musicIdex = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }

    }

    void PlayNextSong()
    {
        musicIdex = (musicIdex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIdex];
        audioSource.Play();
    }
}
