using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void LoadTrainingScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadStoreScene()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
