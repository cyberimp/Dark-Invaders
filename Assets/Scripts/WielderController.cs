using UnityEngine;
using System.Collections;

public class WielderController : Assets.Scripts.CEnemy {


    [SerializeField]
    private GameObject bonusPrefab;
    private GameObject bonus;
	// Update is called once per frame
	void Update () {
	
	}



    override public void Start()
    {
        base.Start();
        bonus = Instantiate(bonusPrefab,Vector3.zero, Quaternion.identity) as GameObject;
        bonus.transform.SetParent(transform, false);
        bonus.GetComponent<BonusController>().Enable(false);
        GetComponent<FixedJoint2D>().connectedBody = bonus.GetComponent<Rigidbody2D>();
    }

    override public void Die()
    {
        bonus.GetComponent<BonusController>().Enable(true);
        bonus.transform.SetParent(null, true);
        base.Die();
        Destroy(gameObject);
    }
}
