using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New CaughtNote Event", menuName = "Events/CaughtNote Event")]
public class CaughtNoteEvent : BaseGameEvent<CaughtNote>
{

}

[System.Serializable]
public class CaughtNoteUnityEvent : UnityEvent<CaughtNote>
{

}
