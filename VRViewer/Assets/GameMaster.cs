using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject ramen;
    public GameObject expandedRamen;

    public GameObject indNames;

    private bool ramenTracker;
    private bool namesTracker;
    private bool rightTracker;

    public void CheckTracker()
    {
        if (rightTracker)
        {
            rightTracker = false;
        }
        else
        {
            rightTracker = true;
        }
        Debug.Log(rightTracker);
    }

    public void ToggleIndividualNames()
    {
        if (namesTracker)
        {
            indNames.SetActive(true);
            namesTracker = false;
        }
        else
        {
            indNames.SetActive(false);
            namesTracker = true;
        }
    }

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
