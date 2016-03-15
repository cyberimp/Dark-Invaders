using UnityEngine;
using System.Collections;

public class DeathRayController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Active(bool isActive)
    {
        GetComponent<BoxCollider2D>().enabled = isActive;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.SendMessage("Die", 2);

        }
    }
}
