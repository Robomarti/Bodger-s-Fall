using System;
using TMPro;
using UnityEngine;

public class CatchingTimer : MonoBehaviour {
    [SerializeField] private TMP_Text timerText;

    private bool isRunning;
    private float timeToShow;
    public TimeSpan TimerTimeSpan { get; private set; }

    private float maximumTimeBeforeGameOver;
    private Action timerCallback;

    private void Awake() {
        isRunning = false;
        timeToShow = 0;
    }

    private void Update() {
        if (!isRunning) return;
        
        timeToShow += Time.deltaTime;
        TimerTimeSpan = TimeSpan.FromSeconds(timeToShow);
        timerText.text = TimerTimeSpan.ToString(@"ss\:ff");

        if (timeToShow >= maximumTimeBeforeGameOver) {
            timerCallback();
            StopTimer();
        }
    }

    public void StartTimer(float maximumTime, Action callback) {
        isRunning = true;
        maximumTimeBeforeGameOver = maximumTime;
        timerCallback = callback;
    }
    
    public void StopTimer() {
        isRunning = false;
    }

    public void PauseTimer(bool toPause) {
        isRunning = !toPause;
    }
}
