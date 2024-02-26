using UnityEngine;
using System;
using TMPro;

public class PlayerUIController : MonoBehaviour{
    private PlayerController pc;
    public TextMeshProUGUI  score_text;
    public TextMeshProUGUI  hp_text;
    public GameObject key_display;
    public GameObject potion_display;

    public void Start() {
        clearUI();

        pc = gameObject.GetComponent<PlayerController>();
    }

    public void Update() {
    }

    public void updateScore(){
        score_text.text = pc.score.ToString();
    }

    public void updateKeys(){
        for(int i=0; i<key_display.transform.childCount; i++)
            if(i < pc.keys) key_display.transform.GetChild(i).gameObject.SetActive(true);
            else key_display.transform.GetChild(i).gameObject.SetActive(false);
    }

    public void updatePots(){
        for(int i=0; i<potion_display.transform.childCount; i++)
            if(i < pc.pots) potion_display.transform.GetChild(i).gameObject.SetActive(true);
            else potion_display.transform.GetChild(i).gameObject.SetActive(false);
    }

    public void updateHorses(){
        hp_text.text = pc.hp.ToString();
    }

    public void clearUI(){
        score_text.text = "0";
        hp_text.text = "0";
        
        for(int i=0; i<key_display.transform.childCount; i++){
            key_display.transform.GetChild(i).gameObject.SetActive(false);
        }

        for(int i=0; i<potion_display.transform.childCount; i++){
            potion_display.transform.GetChild(i).gameObject.SetActive(false);
        }

    }
}