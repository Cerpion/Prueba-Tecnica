using UnityEngine;

public class GameInstaller : GeneralInstaller
{

    protected override void DoStart()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected override void DoInstallDependencies()
    {
    }

    private void OnDestroy()
    {
        //ServiceLocator.Instance.UnregisterService<CommandQueue>();
    }
}
