using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject ramen;
    public GameObject expandedRamen;

    private bool ramenTracker;

    public void ChangeModel()
    {
        if (ramenTracker)
        {
            ramen.SetActive(true);
            expandedRamen.SetActive(false);
            ramenTracker = false;
        }
        else
        {
            ramen.SetActive(false);
            expandedRamen.SetActive(true);
            ramenTracker = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
