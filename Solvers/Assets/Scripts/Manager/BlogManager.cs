using Solvers;
using SOLVERS.MANAGER;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UGS;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BlogManager : MonoBehaviour
{
    [SerializeField] GameObject _postPrefab;
    [SerializeField] GameObject _selectedPost;
    [SerializeField] GameObject _contents;

    [SerializeField] GameObject _postWindow;
    [SerializeField] TextMeshProUGUI _windowTitle;
    [SerializeField] TextMeshProUGUI _windowURL;
    [SerializeField] TextMeshProUGUI _windowDetail;
    [SerializeField] Button _backBtn;
    [SerializeField] Button _deleteBtn;
    private void Start()
    {
        _backBtn.onClick.AddListener(() => RemovePostWindow());
        _deleteBtn.onClick.AddListener(() => RemovePost());

        foreach (Transform content in _contents.transform)
        {
            Destroy(content.gameObject);
        }
        LoadPosts();
    }

    private void LoadPosts()
    {
        UnityGoogleSheet.LoadFromGoogle<string, Solvers.Post>((list, map) => {
            for(int i=0; i< list.Count; i++)
            {
                Solvers.Post post = list[i];
/*              post.DATE = value.DATE;
                post.TITLE = value.TITLE;
                post.WRITER = value.WRITER;
                post.URL = value.URL;
                post.DETAIL = value.DETAIL;*/
                if (post.WRITER == "")
                {
                    continue;
                }

                GameObject postInstance = Instantiate(_postPrefab);
                postInstance.GetComponent<Post>().PostInfo = post;
                postInstance.GetComponent<Button>().onClick.AddListener(() => {
                    _selectedPost = postInstance;
                    PopUpPostWindow(postInstance.GetComponent<Post>().PostInfo);
                });
                postInstance.GetComponent<Post>().Init(post);
                postInstance.transform.SetParent(_contents.transform);
            }
        }, true);
    }

    public void PopUpPostWindow(Solvers.Post postInfo)
    {
        _windowTitle.text = postInfo.TITLE;
        _windowURL.text = postInfo.URL;
        _windowDetail.text = postInfo.DETAIL;
        _postWindow.SetActive(true);
    }

    public void RemovePostWindow()
    {
        _postWindow.SetActive(false);
    }

    public void RemovePost()
    {
        Solvers.Post postInfo = _selectedPost.GetComponent<Post>().PostInfo;
        if (postInfo.WRITER != UserManager.Instance.UserData.handle)
            return;
        
        Destroy(_selectedPost);
        _postWindow.SetActive(false);

        // data도 클리어가 필요함
    }
}
