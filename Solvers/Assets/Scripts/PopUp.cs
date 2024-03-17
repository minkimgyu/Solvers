using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] Button _backBtn;

    [SerializeField] TMP_Text _titleTxt;
    public TMP_Text ApplyTxt { get { return _titleTxt; } }

    [SerializeField] TMP_Text _contentTxt;
    public TMP_Text ContentTxt { get { return _contentTxt; } }

    // Start is called before the first frame update
    void Start()
    {
        _backBtn.onClick.AddListener(() => OnClickBackBtnRequested());
    }

    void OnClickBackBtnRequested()
    {
        Destroy(gameObject);
    }

    public void Initialize(string title, string content, int titleSize, int contentSize)
    {
        _titleTxt.text = title;
        _contentTxt.text = content;

        _titleTxt.fontSize = titleSize;
        _contentTxt.fontSize = contentSize;
    }

    public void Initialize(string title, string content)
    {
        _titleTxt.text = title;
        _contentTxt.text = content;
    }
}
