using UnityEngine;
using System;

public abstract class PlayerController : MonoBehaviour{
    [SerializeField] private float speed = 0;
    public string type;

    private Rigidbody2D rb;
    private Animator anim;

    public Vector3 last_dir = new Vector3(1f, 0, 0);

    public int score = 0;
    public int hp = 600;
    public int keys = 0;
    public int pots = 0;

    private PlayerUIController uic;
    private GameManagerShit gm;

    public AudioClip shoot_sound;
    public AudioSource asource;
    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
        uic = transform.GetComponent<PlayerUIController>();
        gm = GameObject.Find("GameManager").transform.GetComponent<GameManagerShit>();

        asource = gameObject.GetComponent<AudioSource>();
        asource.clip = shoot_sound;

        uic.clearUI();
        uic.updateHorses();
    }

    private bool anim_paused = false;

    void togleAnimations(){
        anim.speed = 1-anim.speed;
        anim_paused = !anim_paused;
    }

    void sneakToggle(){
        anim.speed = 1-anim.speed;
    }

    public String prefix; 
    private String[] anim_names = {"_up", "_up_right", "_right", "_down_right", "_down", "_down_left", "_left", "_up_left"};

    void Update() {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"), 0);
        dir.Normalize();

        if(dir != Vector3.zero) last_dir = dir;
        int mdir = -1;
        if(dir.x != 0f){    
            if(dir.x < 0) mdir = 6;
            else mdir = 2;
            
            if(dir.y != 0f){
                int m = 1;
                if(dir.x > 0) m = -1;

                if(dir.y < 0) mdir = mdir-1*m;
                else mdir = mdir+1*m;
            }
        }else if(dir.y != 0f){    
            if(dir.y < 0) mdir = 4;
            else mdir = 0;
        }
        if(mdir != -1 && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == prefix+anim_names[mdir]) mdir = -1;
        anim.SetInteger("mov_dir", mdir);

        if(Input.GetKeyDown(KeyCode.X)){
            if(pots > 0){
                pots--;
                uic.updatePots();
                gm.popPotion();
            }
        }

        if(Input.GetButton("Fire1")){
            if(!anim_paused) togleAnimations();
            if(mdir != -1){
                sneakToggle();
                Invoke("sneakToggle", .15f);
            }

            rb.velocity = Vector3.zero;
            handleAttack(dir);

                    
        }else if(dir != Vector3.zero){
            if(anim_paused) togleAnimations(); 
            rb.velocity = dir*speed;
        }else if(!anim_paused){
            rb.velocity = Vector3.zero;
            togleAnimations();
        }
    }

    public abstract void handleAttack(Vector3 dir);


    public void addKey(){
        keys++;
        uic.updateKeys();
    }
    public bool removeKey(){
        if(keys == 0) return false;
        keys--;
        uic.updateKeys();

        return true;
    }

    public void addPoto(){
        pots++;
        uic.updatePots();
    }

    public void addScore(int cnt){
        score += cnt;
        uic.updateScore();
    }

    public void addHorsePower(int horses){
        hp+=horses;
        hp = Math.Max(hp, 0);
        uic.updateHorses();

        if(hp <= 0) gm.gameOver();
    }
}