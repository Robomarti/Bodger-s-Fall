using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputController))]
public class PlayersCatchingAbility : MonoBehaviour {
    [SerializeField] private InputController playerController;
    [SerializeField] private float maximumTimeToCatch;
    [SerializeField] private CatchingTimer catchingTimer;
    [SerializeField] private float maximumTimeBeforeGameOver;
    
    [SerializeField] private UnityEvent playVictoryCutsceneEvent;
    [SerializeField] private UnityEvent playLoseCutsceneEvent;

    private bool triesToCatch;
    private float timeToCatch;

    private void Start() {
        timeToCatch = maximumTimeToCatch;
        catchingTimer.StartTimer(maximumTimeBeforeGameOver, PlayerLost);
    }
    
    private void Update() {
        triesToCatch = playerController.RetrieveCatchInput();
        
        // buffer input
        if (triesToCatch) {
            timeToCatch = maximumTimeToCatch;
        }

        if (timeToCatch >= 0f) {
            timeToCatch -= Time.deltaTime;
            triesToCatch = true;
        }
        else {
            triesToCatch = false;
        }
    }

    public void InBodgersRadius(Transform bodgerTransform) {
        if (!triesToCatch) return;
        triesToCatch = false;
        Debug.Log("caught bodger");
        catchingTimer.StopTimer();
        PlayerWon();
    }

    private void PlayerLost() {
        playLoseCutsceneEvent.Invoke();
    }

    private void PlayerWon() {
        playVictoryCutsceneEvent.Invoke();
    }
}
