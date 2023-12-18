using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New CaughtNoteCheckResult Event", menuName = "Events/CaughtNoteCheckResult Event")]
public class CaughtNoteCheckResultEvent : BaseGameEvent<CaughtNoteCheckResult>
{

}

[System.Serializable]
public class CaughtNoteCheckResultUnityEvent : UnityEvent<CaughtNoteCheckResult>
{

}
