using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInstaller : GeneralInstaller
{
    [SerializeField] private GameObject _room;
    protected override void DoStart()
    {
        Application.targetFrameRate = 60;
    }

    protected override void DoInstallDependencies()
    {
        DontDestroyOnLoad(_room.gameObject);

        ServiceLocator.Instance.RegisterServices(CommandQueue.Instance);
    }

   

}
