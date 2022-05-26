using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwith : MonoBehaviour
{
    public void OpenScene (int index)
    {
        SceneManager.LoadScene(index);
        
    }
}
