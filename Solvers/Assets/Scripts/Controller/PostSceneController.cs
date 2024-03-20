using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using SOLVERS.Manager;
using System;

public class PostSceneController : MonoBehaviour
{
    [SerializeField] Button _backBtn;
    [SerializeField] TextMeshProUGUI _title;
    [SerializeField] TextMeshProUGUI _additionalInfo;
    [SerializeField] TMP_InputField _commentInput;
    [SerializeField] Button _commentUploadBtn;
    [SerializeField] GameObject _wirterOnlyObject;

    // Start is called before the first frame update
    void Start()
    {
        // load post
        // check if post's writer is same as user's name
        // if same, _wirterOnlyObject.isActive(true);

        // handle _title & _additionalInfo

        _backBtn.onClick.AddListener(() => GoToBlogSceneRequested());
        _commentUploadBtn.onClick.AddListener(() => UploadComment());
        // set edit mode
        _wirterOnlyObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => EditPost());
        // set delete mode
        _wirterOnlyObject.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => DeletePost());
    }

    void GoToBlogSceneRequested()
    {
        SceneManager.LoadScene("BlogScene");
    }

    void UploadComment()
    {
        // _commentInput.text
        throw new NotImplementedException();
    }
    void EditPost()
    {
        throw new NotImplementedException();
    }

    void DeletePost()
    {
        // delete the current post and load blog scene
        // SceneManager.LoadScene("BlogScene");
        throw new NotImplementedException();
    }
}
