using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Guardar : MonoBehaviour, Interactable
{
    [SerializeField] GameObject UIguardar;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            UIguardar.SetActive(false);
        }

    }
    public void Interact()
    {
        UIguardar.SetActive(true);

    }

    
}
