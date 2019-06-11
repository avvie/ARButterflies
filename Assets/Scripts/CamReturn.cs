using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamReturn : MonoBehaviour
{
    public static CamReturn Instance;
    public Camera main;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        main = GetComponent<Camera>();
    }
    
}
