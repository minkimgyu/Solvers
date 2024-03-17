using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using SOLVERS.Manager;

public class SelectSceneController : MonoBehaviour
{
    [SerializeField] TMP_Text _welcomeTxt;

    [SerializeField] Button _calendarBtn;
    [SerializeField] Button _blogBtn;

    [SerializeField] Button _backBtn;

    // Start is called before the first frame update
    void Start()
    {
        _welcomeTxt.text = "Welcome " + UserManager.Instance.UserData.handle + "!";

        _calendarBtn.onClick.AddListener(() => GoToCalendarSceneRequested());
        _blogBtn.onClick.AddListener(() => GoToBlogSceneRequested());
        _backBtn.onClick.AddListener(() => OnBackToEntryRequested());
    }

    void GoToBlogSceneRequested()
    {
        SceneManager.LoadScene("BlogScene");
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
