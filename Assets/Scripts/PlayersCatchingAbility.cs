using TMPro;
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
    
    [SerializeField] private GameMenu gameMenu;
    [SerializeField] private TMP_Text endTimerText;

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

    public void InBodgersRadius() {
        if (!triesToCatch) return;
        triesToCatch = false;
        catchingTimer.StopTimer();
        PlayerWon();
    }

    private void PlayerLost() {
        endTimerText.text = "Bodger fell to his death";
        gameMenu.SetGameOver();
        playLoseCutsceneEvent.Invoke();
    }

    private void PlayerWon() {
        endTimerText.text = "Your time: \n" + catchingTimer.TimerTimeSpan.ToString(@"ss\:ff");
        gameMenu.SetGameOver();
        playVictoryCutsceneEvent.Invoke();
    }
}
