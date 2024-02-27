using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class WarriorController: PlayerController{
    public GameObject hammer;
    private bool has_hammer = true;

    public override void handleAttack(Vector3 dir){
        if(! has_hammer) return;

        GameObject h = Instantiate(hammer, transform.position, quaternion.identity);
        HammerController hc = h.GetComponent<HammerController>();
        hc.onDestroy += onArrowDestroy;
        hc.dir = last_dir;
        hc.pc = this;
        has_hammer = false;
    }

    public void onArrowDestroy(){
        has_hammer = true;
    }
}