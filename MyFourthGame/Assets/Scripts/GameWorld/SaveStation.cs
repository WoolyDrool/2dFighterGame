using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveStation : MonoBehaviour
{
    public TextMeshProUGUI Prompt;
    public GameObject levelUpScreen;
    public bool canInteract = false;
    // Start is called before the first frame update
    void Start()
    {
        Prompt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("General Interact"))
        {
            Debug.Log("Opened level screen");
            levelUpScreen.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        canInteract = true;
        Debug.Log("Entered trigger");
        if(other.tag == "Player")
        {
            Prompt.gameObject.SetActive(true);
            Debug.Log("Set the prompt to be active");
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        canInteract = false;
        Prompt.gameObject.SetActive(false);
    }
}
