using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject instructionsMenu;

    private void Start() {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);

    }

    public void StartGame() {
        Application.LoadLevel(1);
    }


    public void EndGame() {
        Application.Quit();
    }

    public void Instructions() {
        mainMenu.SetActive(false);
        instructionsMenu.SetActive(true);

    }
}
