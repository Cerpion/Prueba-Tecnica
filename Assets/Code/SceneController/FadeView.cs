using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeMaterial;
    //[SerializeField] private AudioClip _fadeIn;
    //[SerializeField] private AudioClip _fadeOut;
    //[SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;
    [SerializeField] private bool isShowEnd;


    void Start()
    {
        Reset(); 
    }
    private void Reset()
    {
        _fadeMaterial.gameObject.SetActive(false);
        _fadeMaterial.alpha = 0;
    }

    public bool IsShowEnded()
    {
        return isShowEnd;
    }


    public void Show()
    {
        StartCoroutine(ShowFade());
    }

    private IEnumerator ShowFade()
    {
        float fadeTime = 0;
        isShowEnd = false;
        _fadeMaterial.gameObject.SetActive(true);

        //PlaySound(_fadeIn);


        while (fadeTime < 1)
        {

            fadeTime += _speed * Time.deltaTime;
            _fadeMaterial.alpha = fadeTime;

            yield return null;
        }

        _fadeMaterial.alpha = 1;
        isShowEnd = true;

    }

    public void Hidde()
    {
        StartCoroutine(Hide());
    }
    

    private IEnumerator Hide()
    {
        float fadeTime = 1;

        //PlaySound(_fadeOut);

        while (fadeTime > 0)
        {
            fadeTime -= _speed * Time.deltaTime;
            _fadeMaterial.alpha = fadeTime;

            yield return null;
        }

        Reset();
    }
 /*
    private void PlaySound(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
    */
}
