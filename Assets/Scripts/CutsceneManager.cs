using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutsceneManager : MonoBehaviour {
    [SerializeField] private PlayableDirector cutsceneDirector;
    [SerializeField] private TimelineAsset victoryCutscene;
    [SerializeField] private TimelineAsset loseCutscene;

    public void PlayWinCutscene() {
        cutsceneDirector.playableAsset = victoryCutscene;
        cutsceneDirector.Play();
        StartCoroutine(PauseBackground(victoryCutscene));
    }

    public void PlayLoseCutscene() {
        cutsceneDirector.playableAsset = loseCutscene;
        cutsceneDirector.Play();
        StartCoroutine(PauseBackground(loseCutscene));
    }

    private static IEnumerator PauseBackground(TimelineAsset cutScene) {
        yield return new WaitForSeconds((float)cutScene.duration);
        Time.timeScale = 0;
    }
    
}
