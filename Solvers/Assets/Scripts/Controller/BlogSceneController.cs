using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using SOLVERS.MANAGER;

public class BlogSceneController : MonoBehaviour
{
    [SerializeField] Button _backBtn;
    [SerializeField] Button _writePostBtn;

    void Start()
    {
        _backBtn.onClick.AddListener(() => OnBackToSelectSceneRequested());
        _writePostBtn.onClick.AddListener(() => OnLoadPostingScene());
    }

    void OnBackToSelectSceneRequested()
    {
        SceneManager.LoadScene("SelectScene");
    }

    void OnLoadPostingScene()
    {
        SceneManager.LoadScene("PostScene");
    }
}
