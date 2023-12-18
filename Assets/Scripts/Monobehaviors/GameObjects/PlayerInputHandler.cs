using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("References")]
    //[SerializeField] PlayerInputReference _playerInputReference;
    [SerializeField] InputActionAsset _actions;

    private PlayerControls _playerControls;
    private bool _testActivated = false;
    private int _testBeats = 0;
    private float _time;

    public delegate void NoteInputEvent(int p_noteIndex);
    public NoteInputEvent notePerformed;

    private void Awake()
    {
        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
            _actions.LoadBindingOverridesFromJson(rebinds);
    }

    public void PerformNote1(InputAction.CallbackContext context) => PerformNote(0);
    public void PerformNote2(InputAction.CallbackContext context) => PerformNote(1);
    public void PerformNote3(InputAction.CallbackContext context) => PerformNote(2);
    public void PerformNote4(InputAction.CallbackContext context) => PerformNote(3);
    public void PerformNote5(InputAction.CallbackContext context) => PerformNote(4);

    private void PerformNote(int p_index)
    {
        notePerformed.Invoke(p_index);
    }
}
