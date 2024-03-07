using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using SOLVERS.MANAGER;

public class SelectSceneController : MonoBehaviour
{
    [SerializeField] TMP_Text _welcomeTxt;

    [SerializeField] Button _calendarBtn;
    [SerializeField] Button _blogPurposeSelectBtn;

    [SerializeField] GameObject _blogPurposeSelection;
    [SerializeField] Button _blogPostBtn;
    [SerializeField] Button _viewPostBtn;
    [SerializeField] Button _closeBtn;

    [SerializeField] Button _backBtn;

    // Start is called before the first frame update
    void Start()
    {
        _welcomeTxt.text = "Welcome " + UserManager.Instance.UserData.handle + "!";

        _calendarBtn.onClick.AddListener(() => GoToCalendarSceneRequested());
        _blogPurposeSelectBtn.onClick.AddListener(() => OpenBlogPurposeSelectionObject());

        _blogPostBtn.onClick.AddListener(() => GoToBlogPostSceneRequested());
        _viewPostBtn.onClick.AddListener(() => GoToViewPostSceneRequested());
        _closeBtn.onClick.AddListener(() => CloseBlogPurposeSelectionObject());

        _backBtn.onClick.AddListener(() => OnBackToEntryRequested());
    }
    void OpenBlogPurposeSelectionObject()
    {
        _blogPurposeSelection.SetActive(true);
    }

    void CloseBlogPurposeSelectionObject()
    {
        _blogPurposeSelection.SetActive(false);
    }

    void GoToBlogPostSceneRequested()
    {
        SceneManager.LoadScene("BlogPostScene");
    }

    void GoToViewPostSceneRequested()
    {
        SceneManager.LoadScene("ViewPostScene");
    }

    void GoToCalendarSceneRequested()
    {
        SceneManager.LoadScene("CalendarScene");
    }

    void OnBackToEntryRequested()
    {
        UserManager.ClearLoginData();
        SceneManager.LoadScene("StartScene");
    }
}
