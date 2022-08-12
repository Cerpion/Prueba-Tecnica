using UnityEngine;
using System.Collections.Generic;
public class EventQueue : MonoBehaviour
{
    private Queue<EventData> _currentEvents;
    private Queue<EventData> _nextEvents;

    private Dictionary<EventId, List<EventObserver>> _observer;

    private void Awake()
    {
        _currentEvents = new Queue<EventData>();
        _nextEvents = new Queue<EventData>();

        _observer = new Dictionary<EventId, List<EventObserver>>();
    }

    public void Subscribe(EventId eventId, EventObserver eventObserver)
    {

        if (!_observer.TryGetValue(eventId, out var eventObservers))
        {
            eventObservers = new List<EventObserver>();
        }

        eventObservers.Add(eventObserver);
        _observer[eventId] = eventObservers;

    }

    public void Unsuscribe(EventId eventId, EventObserver eventObserver)
    {
        _observer[eventId].Remove(eventObserver);
    }

    public void EnqueueEvent(EventData evenData)
    {
        _nextEvents.Enqueue(evenData);
        Debug.Log(evenData.EventId);
    }

    private void LateUpdate()
    {
        ProcessEvents();
    }

    private void ProcessEvents()
    {
        var tempCurrentEvents = _currentEvents;
        _currentEvents = _nextEvents;
        _nextEvents = tempCurrentEvents;

        foreach (var currentEvent in _currentEvents)
        {
            ProcessEvent(currentEvent);
        }

        _currentEvents.Clear();
    }

    private void ProcessEvent(EventData eventData)
    {
        if (_observer.TryGetValue(eventData.EventId, out var eventObservers))
        {

            foreach (var eventObserver in eventObservers)
            {
                eventObserver.Process(eventData);
            }

        }
    }

}
