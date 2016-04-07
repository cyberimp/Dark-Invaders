using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

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
        if (!gun && !left && !right)
            gameObject.SendMessageUpwards("GoBerserk");
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyFinish")
            return;
        base.OnTriggerEnter2D(other);
    }

    public override void Die()
    {
        base.Die();
        EventSystem.current.SendMessage("Victory");
    }

}
