using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiodeEscena : MonoBehaviour
{
    public int escena;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")

        {
            SceneManager.LoadScene(escena);
        }
    }
}

