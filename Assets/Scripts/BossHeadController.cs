using UnityEngine;
using System.Collections;

public class BossHeadController : Assets.Scripts.CEnemy{

    private bool left = true;
    private bool right = true;
    private bool gun = true;
	// Update is called once per frame
	void Update () {
	
	}

    public override void ApplyDamage(float amount)
    {
        if (!left && !right && !gun)
            base.ApplyDamage(amount);

    }
    public void Destroyed(int what)
    {
        switch (what)
        {
            case 3:
                gun = false;
                break;
            case 1:
                left = false;
                break;
            case 2:
                right = false;
                break;
        }
    }

}
