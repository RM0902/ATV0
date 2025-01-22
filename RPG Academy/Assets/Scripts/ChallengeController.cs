using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeController : MonoBehaviour, Interactable
{

    public int escena;
    public void Interact()
    {
         
     SceneManager.LoadScene(escena);
        
    }
}
