using System.Collections;
using UnityEngine;

public class PlayAirBalloonSound : MonoBehaviour {
    [SerializeField] private AudioClip fromTheAir;
    
    private void Start() {
        StartCoroutine(PlayBalloonSound());;
    }

    private IEnumerator PlayBalloonSound() {
        yield return new WaitForSeconds(1f);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlaySoundEffects(fromTheAir);
    }
}
