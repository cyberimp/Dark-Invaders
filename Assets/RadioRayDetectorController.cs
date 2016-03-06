using UnityEngine;
using System.Collections;

public class RadioRayDetectorController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        SendMessageUpwards("Ok",SendMessageOptions.DontRequireReceiver);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "radio left")
            SendMessageUpwards("Right", SendMessageOptions.DontRequireReceiver);
        else if (gameObject.name == "radio right")
            SendMessageUpwards("Left", SendMessageOptions.DontRequireReceiver);
    }
}
