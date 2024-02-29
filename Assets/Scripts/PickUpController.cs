using UnityEngine;

public class PickUpController: MonoBehaviour{
    public bool key = false;
    public int score = 0;
    public int hp = 0;
    public bool potion = false;

    public bool level_warp = false;
    public string to_level = "";

    private GameManagerShit gm;
    private PlayerController pc;

    private AudioSource asource;
    public AudioClip pickup_sound;


    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManagerShit>();
        asource = GameObject.Find("audio").GetComponent<AudioSource>();
    }


    public void OnTriggerEnter2D(Collider2D other){
        if(gm.pc == null) return;

        if(potion && other.CompareTag("Player projectile")){
            gm.popPotion();
            Destroy(gameObject);
        }else if(other.CompareTag("Player")){
            if(key) gm.pc.addKey();
            if(potion) gm.pc.addPoto();
            if(score > 0) gm.pc.addScore(score);
            if(hp > 0) gm.pc.addHorsePower(hp);
            if(level_warp) gm.gotoScene(to_level);

            asource.clip = pickup_sound;
            asource.Play();
            Destroy(gameObject);
        }
    }
}