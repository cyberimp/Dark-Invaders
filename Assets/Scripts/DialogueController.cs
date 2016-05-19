using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
    public class DialogueMessage
    {
        public string text;
        public float lifetime;
        public int face;
        public DialogueMessage(string t1,float f1, int i1)
        {
            text = t1;
            lifetime = f1;
            face = i1;
        }
    }
    [SerializeField]
    private TextType typewriter;
    [SerializeField]
    private Sprite[] facesToSmash;
    [SerializeField]
    private Image face;
    private List<DialogueMessage> messages;
 	// Use this for initialization
	void Start () {
        messages = new List<DialogueMessage>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire") && typewriter.isFinished)
        {
            messages[0].lifetime = 0;
        }

    }

    void FixedUpdate()
    {
        if (messages.Count == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            messages[0].lifetime -= Time.fixedDeltaTime;
            if (messages[0].lifetime < 0)
            {
                messages.RemoveAt(0);
                if (messages.Count > 0)
                {
                    typewriter.TypeThis(messages[0].text);
                    face.sprite = facesToSmash[messages[0].face];
                }
            }

        }

    }

    public void AddMessage(DialogueMessage text)
    {
        if (messages.Count == 0)
            messages.Add(new DialogueMessage("", 0f, 0));
        messages.Add(text);

    }
}
