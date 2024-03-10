using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using SOLVERS.MANAGER;

public class PostSceneController : MonoBehaviour
{
    [SerializeField] Button _backBtn;

    // Start is called before the first frame update
    void Start()
    {
        _backBtn.onClick.AddListener(() => OnBackToEntryRequested());
    }
   
    void OnBackToEntryRequested()
    {
        SceneManager.LoadScene("BlogScene");
    }
}
