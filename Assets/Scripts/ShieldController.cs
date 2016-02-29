using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour
{
    private float power = 1;
    public float powerSpeed = 0.2f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, power);
        if (power < 1)
            power += Time.deltaTime * powerSpeed;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (power > 0)
        {
            if (collision.tag == "Enemy")
            {
                collision.gameObject.SendMessage("ApplyDamage", 100.0f);
                power -= 0.2f;
            }
            else if (collision.tag == "EnemyBullet")
            {
                Destroy(collision.gameObject);
                power -= 0.1f;
            }
        }
    }
}
