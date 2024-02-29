using UnityEngine;

public class DoorController: MonoBehaviour{
    private PlayerController pc;
    private AudioSource asource;
    public AudioClip sound;

    void Start(){
        asource = GameObject.Find("audio").GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(pc == null) pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            if(pc.removeKey()){
                asource.clip = sound;
                asource.Play();
                Destroy(gameObject);
            }
        }
    }
}