using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class GameMenu : Menus {
    [SerializeField] private InputController playerController;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private CatchingTimer catchingTimer;
    
    private bool isPaused;
    private bool isGameOver;

    public void SetGameOver() {
        isGameOver = true;
    }

    private void Start() {
        isGameOver = false;
        isPaused = pauseMenu.activeSelf;
    }

    private void Update() {
        if (isGameOver) return;
        if (playerController.RetrievePauseKeyDown()) {
            ToggleGamePause();
        }
    }
    
    public void ToggleGamePause() {
        if (isPaused) {
            pauseMenu.SetActive(false);
            isPaused = false;
            catchingTimer.PauseTimer(false);
            Time.timeScale = 1;
        }
        else {
            pauseMenu.SetActive(true);
            isPaused = true;
            catchingTimer.PauseTimer(true);
            Time.timeScale = 0;
        }
    }
}
