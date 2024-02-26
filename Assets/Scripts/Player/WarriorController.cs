using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class WarriorController: PlayerController{
    public GameObject hammer;
    private bool has_hammer = false;

    void Start(){
        type = "Warrior";
        base.Start();
    }

    public override void handleAttack(Vector3 dir){
        if(! has_hammer) return;

        GameObject h = Instantiate(hammer, transform.position, quaternion.identity);
        //ArrowController ac = a.GetComponent<ArrowController>();
        //ac.onDestroy += onArrowDestroy;
        //ac.dir = last_dir;
        //ac.pc = this;
        //has_hammer = false;
    }

    public void onArrowDestroy(){
        has_hammer = true;
    }
}