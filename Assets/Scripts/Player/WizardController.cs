using Unity.Mathematics;
using UnityEngine;
public class  WizardController: PlayerController{
    public GameObject magical_thingy_that_i_do_not_know_how_it_should_be_called;
    private bool has_magic = true;

    public override void handleAttack(Vector3 dir){
        if(! has_magic) return;

        GameObject mt = Instantiate(magical_thingy_that_i_do_not_know_how_it_should_be_called, transform.position, quaternion.identity);
        MagicThingyController mtc = mt.GetComponent<MagicThingyController>();
        mtc.onDestroy += onSwordDestroy;
        mtc.dir = last_dir;
        mtc.pc = this;
        has_magic = false;
    }

    public void onSwordDestroy(){
        has_magic = true;
    }
}