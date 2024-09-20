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
    }

    public void PlayLoseCutscene() {
        cutsceneDirector.playableAsset = loseCutscene;
        cutsceneDirector.Play();
    }
}
