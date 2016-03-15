using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Scripts
{
    public class CEnemy : MonoBehaviour
    {
        public float HP;
        public GameObject explosion;

        private GameObject player;

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public virtual void ApplyDamage(float value)
        {
            HP -= value;
            if (HP < 0)
                Die();
        }

        public virtual void Die()
        {
            GameObject exp = Instantiate(explosion);
            exp.transform.SetParent(transform, false);
            Destroy(exp, 10);
            gameObject.tag = "MostlyHarmless";
        }
    }
}
