using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public delegate void ScoreEvents();
    public delegate void GameEvents();
    public static event ScoreEvents OnPickup;
    public static event ScoreEvents OnDropoff;

    public static event ScoreEvents OnTreatIncrease;
    public static event GameEvents OnDeath;




    [SerializeField]
    Text txtHumans;
    [SerializeField]
    Text txtThreatLevel;



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

    private void OnEnable() {
        OnPickup += UpdateHumans;
        OnTreatIncrease += UpdateThreat;
    }
    private void OnDisable() {
        OnPickup = UpdateHumans;
        OnTreatIncrease -= UpdateThreat;
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
        OnDeath();
    }


    void UpdateHumans() {
        currentHumans++;
        txtHumans.text = currentHumans.ToString();
        
        if(currentThreat % 5 == 0) { // every five humans increase threat by one
            CallOnTreatIncrease();
        }
    }

    void UpdateThreat() {
        currentThreat++;
        txtThreatLevel.text = currentThreat.ToString();
        //TODO send more millitary
    }
}
