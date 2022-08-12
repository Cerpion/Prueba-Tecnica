using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimController : MonoBehaviour
{
    [SerializeField] private List<string> _animationName;
    [SerializeField] private AnimButton _animButton;

    [SerializeField] private Animator _player;

    [SerializeField] private SceneController sceneController;


    private void Awake()
    {
        foreach (var item in _animationName)
        {
            var animButton = Instantiate(_animButton, transform);
            animButton.Configure(sceneController, item.ToString(), _player);
        }
    }





}
