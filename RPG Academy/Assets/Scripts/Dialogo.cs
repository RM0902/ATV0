using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

[System.Serializable]
public class Dialogo
{
    [SerializeField] List<string> lines;
    //[SerializeField] List<Image> imagenes;

    public List<string> Lines 
    {
        get { return lines; }
    }
}
