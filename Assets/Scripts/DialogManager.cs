using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject dialogNameBox;
    public string[] dialogLines;
    public int currentLine;
    public static DialogManager instance;
    private bool justStarted;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //dialogText.text = dialogLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                if(!justStarted)
                {
                    currentLine++;

                    if(currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        PlayerController.instance.canMove = true;
                    } else
                    {
                        checkIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }else{
                    justStarted = false;
                }
            }
        }
    }

    public void showDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;
        currentLine = 0;

        checkIfName();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        justStarted = true;

        dialogNameBox.SetActive(isPerson);

        PlayerController.instance.canMove = false;
    }

    public void checkIfName()
    {
        if(dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }

}
