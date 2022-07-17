using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerTile : MonoBehaviour
{
    [SerializeField] public int livesLeft = 6;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.Find(livesLeft.ToString() + "Turn").gameObject.SetActive(true);
    }

    public void DecreaseLife()
    {
        this.transform.Find(livesLeft.ToString() + "Turn").gameObject.SetActive(false);
        livesLeft--;
        if(livesLeft > 0)
        {
            this.transform.Find(livesLeft.ToString() + "Turn").gameObject.SetActive(true);
        }
        
    }
    public int GetRemainingLifes()
    {
        return livesLeft;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
