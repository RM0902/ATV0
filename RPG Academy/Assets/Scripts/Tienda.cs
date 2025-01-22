using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour, Interactable
{
    [SerializeField] GameObject UITienda;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            UITienda.SetActive(false);
        }

    }
    public void Interact()
    {
        UITienda.SetActive(true);

    }
}
