using UnityEngine;

// with https://www.youtube.com/watch?v=xswEpNpucZQ
public class AudioManager : MonoBehaviour {
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundEffectsSource;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip backgroundMusic;

    public static AudioManager instance;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    
    private void Start() {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySoundEffects(AudioClip clip) {
        soundEffectsSource.PlayOneShot(clip);
    }
}
