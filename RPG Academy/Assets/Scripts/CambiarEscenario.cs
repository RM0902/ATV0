using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenario : MonoBehaviour
{
        public int escena;
        public void CambiarEscena()
        {
            SceneManager.LoadScene(escena);
  
        }
}
