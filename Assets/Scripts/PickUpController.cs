using UnityEngine;

public class PickUpController: MonoBehaviour{
    public bool key = false;
    public int score = 0;
    public int hp = 0;
    public bool potion = false;

    private GameManagerShit gm;
    private PlayerController pc;


    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManagerShit>();
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }


    public void OnTriggerEnter2D(Collider2D other){
        if(potion && other.CompareTag("Player projectile")){
            gm.popPotion();
            Destroy(gameObject);
        }else if(other.CompareTag("Player")){
            if(key) pc.addKey();
            if(potion) pc.addPoto();
            if(score > 0) pc.addScore(score);
            if(hp > 0) pc.addHorsePower(hp);

            Destroy(gameObject);
        }
    }
}