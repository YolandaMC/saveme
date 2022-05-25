using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public List<Collectable> collectables;
    // Start is called before the first frame update
    void Start()
    {
        collectables = new List<Collectable>(GetComponentsInChildren<Collectable>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
