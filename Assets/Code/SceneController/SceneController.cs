using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    [SerializeField] string _nextScene;
    [SerializeField] Button _button;
    [SerializeField] PanelAnimController _panelAnimController;

    void Start()
    {
        _button.onClick.AddListener(NextScene);
        _button.interactable = false;
    }

    private void NextScene()
    {

        ServiceLocator.Instance.GetService<CommandQueue>().
          AddCommand(new LoadSceneCommand(_nextScene));
    }

    public void AnimSelect()
    {
        _button.interactable = true ;
    }
}
