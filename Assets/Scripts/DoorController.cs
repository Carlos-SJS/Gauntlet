using UnityEngine;

public class DoorController: MonoBehaviour{
    private PlayerController pc;

    void Start(){
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(pc.removeKey())
                Destroy(gameObject);
        }
    }
}