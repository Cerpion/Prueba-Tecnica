using UnityEngine;

public class EventQueueInstaller : Installer
{
    [SerializeField] private EventQueue _eventQueue;
    public override void Install(ServiceLocator serviceLocator)
    {
        DontDestroyOnLoad(_eventQueue.gameObject);
        serviceLocator.RegisterServices(_eventQueue);
    }
}
