using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject UIPausa;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIPausa.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            UIPausa.SetActive(false);
        }

    }
}
