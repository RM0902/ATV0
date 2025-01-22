using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnHideDialog;
    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    Dialogo dialog;
    int currentLine = 0;
    bool isTyping;

    public IEnumerator ShowDialog(Dialogo dialogo)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        this.dialog = dialogo;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialogo.Lines[0]));
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                currentLine = 0;
                OnHideDialog?.Invoke();
            }
        }

    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray()) 
        { 
            dialogText.text += letter; 
            yield return new WaitForSeconds(1f / lettersPerSecond);

        }
        isTyping = false;
    }
}
