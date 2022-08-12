using UnityEngine;

public class FadeScreenInstaller : Installer
{
    [SerializeField] private FadeView _fadeView;
    public override void Install(ServiceLocator serviceLocator)
    {
        DontDestroyOnLoad(_fadeView);
        serviceLocator.RegisterServices(_fadeView);
    }
}
