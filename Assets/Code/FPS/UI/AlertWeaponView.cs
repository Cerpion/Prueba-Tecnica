using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertWeaponView : MonoBehaviour, EventObserver
{

    [SerializeField] private TMP_Text _nameWeapon;
    [SerializeField] private GameObject _alertPanel;

    private void Start()
    {
        _alertPanel.SetActive(false);

        ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventId.ShowAlertWeapon, this);
        ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventId.HideAlertWeapon, this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.GetService<EventQueue>().Unsuscribe(EventId.ShowAlertWeapon, this);
        ServiceLocator.Instance.GetService<EventQueue>().Unsuscribe(EventId.HideAlertWeapon, this);
    }


    public void Process(EventData eventData)
    {
        if (eventData.EventId == EventId.ShowAlertWeapon)
        {

            var nameWeaponEvent = (AlertWeaponEvent)eventData;
            _nameWeapon.text = nameWeaponEvent.NameWeapon;
            _alertPanel.SetActive(true);

            return;
        }

        if (eventData.EventId == EventId.HideAlertWeapon)
        {
            _alertPanel.SetActive(false);

            return;
        }
    }
}
