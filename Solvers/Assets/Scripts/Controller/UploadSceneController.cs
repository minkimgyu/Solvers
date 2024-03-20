using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using SOLVERS.Manager;
using System;

public class UploadSceneController : MonoBehaviour
{
    [SerializeField] Button _backBtn;
    [SerializeField] TMP_InputField _titleInput;
    [SerializeField] Button _addTextBtn;
    [SerializeField] Button _addCodeBtn;
    [SerializeField] Button _uploadBtn;

    void Start()
    {
        _backBtn.onClick.AddListener(() => GoToBlogSceneRequested());
        _addTextBtn.onClick.AddListener(() => AddText());
        _addCodeBtn.onClick.AddListener(() => AddCode());
        _uploadBtn.onClick.AddListener(() => UploadPost());
    }

    void GoToBlogSceneRequested()
    {
        SceneManager.LoadScene("BlogScene");
    }

    void AddText()
    {
        throw new NotImplementedException();
    }

    void AddCode()
    {
        throw new NotImplementedException();
    }

    void UploadPost()
    {
        throw new NotImplementedException();
    }
}
