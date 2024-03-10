using SOLVERS.MANAGER;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UGS;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostManager : MonoBehaviour
{
    [SerializeField] TMP_InputField _titleInput;
    [SerializeField] TMP_InputField _urlInput;
    [SerializeField] TMP_InputField _detailInput;
    [SerializeField] Button _uploadBtn;

    private void Start()
    {
        _uploadBtn.onClick.AddListener(() => UploadPost(_titleInput.text, _urlInput.text, _detailInput.text));
    }

    private void UploadPost(string title, string problemUrl, string deatil)
    {
        var newData = new Solvers.Post();
        newData.DATE = DateTime.Now.ToString();
        newData.WRITER = UserManager.Instance.UserData.handle;
        newData.TITLE = title;
        newData.URL = problemUrl;
        newData.DETAIL = deatil;

        UnityGoogleSheet.Write<Solvers.Post>(newData);

        SceneManager.LoadScene("BlogScene");
    }
}
