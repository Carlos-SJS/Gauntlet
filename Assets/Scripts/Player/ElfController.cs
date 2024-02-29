using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class ElfController: PlayerController{
    public GameObject arrow;
    private bool has_arrow = true;

    public override void handleAttack(Vector3 dir){
        if(! has_arrow) return;
        asource.Play();
        GameObject a = Instantiate(arrow, transform.position, quaternion.identity);
        ArrowController ac = a.GetComponent<ArrowController>();
        ac.onDestroy += onArrowDestroy;
        ac.dir = last_dir;
        ac.pc = this;
        has_arrow = false;
    }

    public void onArrowDestroy(){
        has_arrow = true;
    }
}