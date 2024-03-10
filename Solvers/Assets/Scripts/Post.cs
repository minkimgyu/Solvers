using SOLVERS.MANAGER;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Post : MonoBehaviour
{
    public Solvers.Post PostInfo { get; set; }
    [SerializeField] TextMeshProUGUI _writer;
    [SerializeField] TextMeshProUGUI _title;
    public void Init(Solvers.Post postInfo)
    {
        PostInfo = postInfo;
        _writer.text = postInfo.WRITER;
        _title.text = postInfo.TITLE;

        GetComponent<Button>().onClick.AddListener(() => PopUpPostWindow(PostInfo));
    }

    public void PopUpPostWindow(Solvers.Post postInfo)
    {
        Debug.Log("pop up");
/*        _windowTitle.text = postInfo.TITLE;
        _windowURL.text = postInfo.URL;
        _windowDetail.text = postInfo.DETAIL;
        _postWindow.SetActive(true);*/
    }

    public void RemovePostWindow()
    {
        //_postWindow.SetActive(false);
    }

    public void RemovePost()
    {
        if (PostInfo.WRITER != UserManager.Instance.UserData.handle)
            return;
        //Destroy(gameObject);
    }
}
