using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void LoadTrainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
