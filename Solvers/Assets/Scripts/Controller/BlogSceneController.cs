using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using SOLVERS.Manager;

public class BlogSceneController : MonoBehaviour
{
    [SerializeField] Button _backBtn;
    [SerializeField] Button _uploadBtn;

    void Start()
    {
        _backBtn.onClick.AddListener(() => GoToSelectSceneRequested());
        _uploadBtn.onClick.AddListener(() => GoToUploadSceneRequested());
    }

    void GoToSelectSceneRequested()
    {
        SceneManager.LoadScene("SelectScene");
    }

    void GoToUploadSceneRequested()
    {
        SceneManager.LoadScene("UploadScene");
    }

}
