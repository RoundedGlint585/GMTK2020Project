using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string Size = "8x8";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
