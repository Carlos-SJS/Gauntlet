using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using Unity.Mathematics;

public class GameManagerShit: MonoBehaviour{
    public List<GameObject> peeps_in_frame = new List<GameObject>();

    public PlayerController pc;

    public Vector3 spwawn_position;

    public GameObject[] heroes;

    private void Start(){
        GameObject ch = Instantiate(heroes[GameState.character], spwawn_position, quaternion.identity);
        pc = ch.GetComponent<PlayerController>();
        pc.score = GameState.score;
        pc.hp = GameState.hp;
        pc.pots = GameState.pots;
        pc.keys = GameState.keys;

        Debug.Log("Recorded hp = " + GameState.hp);

        GameObject.Find("Main Camera").GetComponent<CameraController>().target = ch.transform;

        Invoke("tickHP", 1f);
    }

    public void popPotion(){
        while(peeps_in_frame.Count > 0) Destroy(peeps_in_frame[0]);
    }

    public void getUIComponents(string type, out TextMeshProUGUI score, out TextMeshProUGUI hp, out GameObject keys, out GameObject pots){        
        Transform cont = GameObject.Find("Canvas").transform.GetChild(1).Find(type);

        score = cont.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        hp = cont.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        keys = cont.GetChild(2).gameObject;
        pots = cont.GetChild(3).gameObject;

        Debug.Log("Got ui shit");
    }

    private void tickHP(){
        pc.addHorsePower(-1);
        Invoke("tickHP", 1f);

    }

    public void gameOver(){
        GameState.score = pc.score;
        SceneManager.LoadScene("GameOver");
    }

    public void gotoScene(String scene){
        GameState.score = pc.score;
        GameState.hp = pc.hp;
        SceneManager.LoadScene(scene);
    }
}