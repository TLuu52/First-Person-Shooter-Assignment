using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelCounter : MonoBehaviour
{
    public Text levelText;
    public int buildIndex;
 
 
    private void Start()
    {
        levelText.text = Application.loadedLevelName;
    }

    public void levelUpdate ()
    {
    }
}
