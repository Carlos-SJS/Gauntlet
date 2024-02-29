using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager: MonoBehaviour{
    public String[] char_name = {"Valkyrie", "Elf", "Warrior", "Wizard"};
    void Start(){
        GameObject.Find("score final").GetComponent<TextMeshProUGUI>().text = "Your score: " + GameState.score;
        GameObject.Find("congrats").GetComponent<TextMeshProUGUI>().text = "You are the strongest " + char_name[GameState.character] + " i have ever seen";
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Menu");
    }
}