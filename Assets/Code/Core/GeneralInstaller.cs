using UnityEngine;

public abstract class GeneralInstaller : MonoBehaviour
{
    [SerializeField] private Installer[] _installers;

    private void Awake()
    {
        InstalDependences();
        DoStart();
    }

    protected abstract void DoStart();

    private void InstalDependences()
    {
        foreach (var installer in _installers)
        {
            installer.Install(ServiceLocator.Instance);
        }

        DoInstallDependencies();
    }

    protected abstract void DoInstallDependencies();


}
