
public class AlertWeaponEvent : EventData
{
    public readonly string NameWeapon;

    public AlertWeaponEvent(string nameWeapon) : base(EventId.ShowAlertWeapon)
    {
        NameWeapon = nameWeapon;
    }
}
