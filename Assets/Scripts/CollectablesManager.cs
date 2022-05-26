using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public List<Collectable> collectables;
    void Start()
    {
        collectables = new List<Collectable>(GetComponentsInChildren<Collectable>());
    }

    void Update()
    {
        
    }
}
