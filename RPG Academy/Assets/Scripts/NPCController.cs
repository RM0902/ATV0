using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialogo dialogo;
    [SerializeField] GameObject Imagen;

    public void Interact()
    {
        Imagen.SetActive(true);
        StartCoroutine(DialogueManager.Instance.ShowDialog(dialogo));
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Imagen.SetActive(false);
        }

    }

}
