using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undestroyable : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
