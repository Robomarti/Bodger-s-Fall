using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class GameMenu : Menus {
    [SerializeField] private InputController playerController;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private CatchingTimer catchingTimer;
    
    private bool isPaused;

    private void Start() {
        isPaused = pauseMenu.activeSelf;
    }

    private void Update() {
        if (playerController.RetrievePauseKeyDown()) {
            ToggleGamePause();
        }
    }
    
    public void ToggleGamePause() {
        if (isPaused) {
            pauseMenu.SetActive(false);
            isPaused = false;
            catchingTimer.PauseTimer(false);
        }
        else {
            pauseMenu.SetActive(true);
            isPaused = true;
            catchingTimer.PauseTimer(true);
        }
    }
}
