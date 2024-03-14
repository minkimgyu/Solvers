using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CalendarSceneController : MonoBehaviour
{
    [SerializeField] Button _backBtn;

    // Start is called before the first frame update
    void Start()
    {
        _backBtn.onClick.AddListener(() => GoToSelectSceneRequested());
    }

    void GoToSelectSceneRequested()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
