using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager: MonoBehaviour{
    void Start(){
        GameObject.Find("score final").GetComponent<TextMeshProUGUI>().text = "Your score: " + GameState.score;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Menu");
    }
}