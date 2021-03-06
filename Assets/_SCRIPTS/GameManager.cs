using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public delegate void ScoreEvents();
    public delegate void GameEvents();
    public static event ScoreEvents OnPickup;
    public static event ScoreEvents OnDropoff;

    public static event ScoreEvents OnTreatIncrease;
    public static event GameEvents OnDeath;
    public static event GameEvents RespawnPlayer;




    [SerializeField]
    Text txtHumans;
    [SerializeField]
    Text txtThreatLevel;

    [SerializeField]
    Text finalHumans;
    [SerializeField]
    Text finalThreatLevel;

    float respawnTime = 3f;

    public int currentHumans = 0;
    public int currentThreat = 0;


    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance {
        get { return instance; }
    }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    #endregion

    private void Start() {
        gameOverScreen.SetActive(false);
    }
    private void OnEnable() {
        OnPickup += UpdateHumans;
        OnDeath += CallGameOver;
        OnTreatIncrease += UpdateThreat;
        

    }
    private void OnDisable() {
        OnPickup -= UpdateHumans;
        OnTreatIncrease -= UpdateThreat;
        OnDeath -= CallGameOver;
    }

    public void CallOnPickup() {
        
        OnPickup();
    }

    public void CallOnDropoff() {
        OnDropoff();
    }

    public void CallOnTreatIncrease() {
        OnTreatIncrease();
    }

    public void CallOnDeath() {
        StartCoroutine(WaitForRespawn());
        OnDeath();
        
    }

    public void CallRespawn() {
        RespawnPlayer();
    }

    void UpdateHumans() {
        currentHumans++;
        txtHumans.text = currentHumans.ToString();
        finalHumans.text = "Final Humans Abducted: " + currentHumans.ToString();

        if (currentHumans % 5 == 0) { // every five humans increase threat by one
            CallOnTreatIncrease();
        }
    }

    void UpdateThreat() {
        currentThreat++;
        txtThreatLevel.text = currentThreat.ToString();
        finalThreatLevel.text = "Final Threat Level: " + currentThreat.ToString();
        //TODO send more millitary
    }

    IEnumerator WaitForRespawn() {
        yield return new WaitForSeconds(respawnTime);
        this.gameObject.SetActive(true);
    }

    public void CallGameOver(){
        //Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }


    public void EndGame() {
        Application.Quit();
    }

    public void Restart() {
        gameOverScreen.SetActive(false);
        Application.LoadLevel(1);
    }


}
