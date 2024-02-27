using Unity.Mathematics;
using UnityEngine;
public class  ValkyraeController: PlayerController{
    public GameObject sword;
    private bool has_sword = true;

    public override void handleAttack(Vector3 dir){
        if(! has_sword) return;

        GameObject s = Instantiate(sword, transform.position, quaternion.identity);
        SwordController sc = s.GetComponent<SwordController>();
        sc.onDestroy += onSwordDestroy;
        sc.dir = last_dir;
        sc.pc = this;
        has_sword = false;
    }

    public void onSwordDestroy(){
        has_sword = true;
    }
}