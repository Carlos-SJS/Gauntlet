using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManagerShit: MonoBehaviour{
    public List<GameObject> peeps_in_frame = new List<GameObject>();

    private PlayerController pc;

    private void Start(){
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

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
}