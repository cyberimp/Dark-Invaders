using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{
    private float rotSpeed = 0f;
    private Rigidbody2D cachedBody;
    private float cachedAngle;


    // Use this for initialization
    void Start()
    {
        cachedBody = GetComponent<Rigidbody2D>();
        //        cachedAngle = transform.rotation.z+90;
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 200);
        //GetComponent<Rigidbody2D>().angularVelocity = 90;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            //do drunk rocket style
        }
        else {
            GameObject nearest = enemies[0];
            float distance = (transform.position - nearest.transform.position).sqrMagnitude;
            foreach (GameObject enemy in enemies)
            {
                float newDistance = (transform.position - enemy.transform.position).sqrMagnitude;
                if (newDistance < distance)
                {
                    nearest = enemy;
                    distance = newDistance;
                }

            }
            float myAngle = transform.rotation.eulerAngles.z;
            float enemyAngle = Vector3.Angle(Vector3.up, nearest.transform.position - transform.position);
            transform.Rotate(new Vector3(0, 0, Mathf.Clamp(Mathf.DeltaAngle(myAngle,enemyAngle),
                                                        -90f*Time.deltaTime,90f*Time.deltaTime)));
        }

        //      cachedAngle = transform.rotation.z + 90;
        if (cachedBody == null)
        {
            cachedBody = GetComponent<Rigidbody2D>();
            //            cachedAngle = transform.rotation.z+90;
        }
        //       cachedBody.AddRelativeForce(Vector2.up *2);
        //transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
        cachedBody.velocity = Vector2.zero;
        cachedBody.AddRelativeForce(Vector2.up * 200);
    }

    void Awake()
    {
    }

    void Left()
    {
        //        GetComponent<Rigidbody2D>().angularVelocity = 90;
        //        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rotSpeed = -90f;
    }

    void Right()
    {
        //        GetComponent<Rigidbody2D>().angularVelocity = -90;
        //        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        rotSpeed = 90f;
    }

    void Ok()
    {
        //        GetComponent<Rigidbody2D>().angularVelocity = 0;
        rotSpeed = 0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
            Destroy(gameObject);
        if (other.tag == "Enemy")
        {
            other.SendMessage("ApplyDamage", 5);
            Destroy(gameObject);
        }

    }
}
