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

        public GameObject player;

        private LevelController lc;

        public virtual void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public virtual void OnEnable()
        {
            lc = FindObjectOfType<LevelController>();
            lc.AddEnemy(gameObject);
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
            exp.transform.SetParent(null, true);
            Destroy(exp, 10);
            gameObject.tag = "MostlyHarmless";
        }

        void OnDestroy()
        {
            if (lc!=null)
                lc.DelEnemy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            string otherTag = other.gameObject.tag;
            if (otherTag == "Player")
            {
                player.SendMessage("Die", 1);
                gameObject.SendMessage("ApplyDamage", 100);
            }
            if (otherTag == "EnemyFinish")
            {
                Destroy(gameObject);
            }
        }

    }
}
