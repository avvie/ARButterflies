using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyCounter : MonoBehaviour
{
    public static ButterflyCounter Instance;
    public int Counter = 0;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
