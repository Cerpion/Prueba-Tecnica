using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _nameButton;
    [SerializeField] private SceneController _sceneController;

    private Animator _playerAnimator;
    private int _idAnimation;

    public void Configure(SceneController sceneController, string nameAnim, Animator playerAnimator)
    {
        _sceneController = sceneController;
        _nameButton.text = nameAnim;
        _idAnimation = Animator.StringToHash(nameAnim);
        _playerAnimator = playerAnimator;
    }

    private void Start()
    {
        _button.onClick.AddListener(PlayAnimation);
    }


    private void PlayAnimation()
    {
        _playerAnimator.CrossFade(_idAnimation, 0.01f);
        _sceneController.AnimSelect();
    }

}
