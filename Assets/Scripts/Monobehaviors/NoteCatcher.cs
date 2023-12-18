using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCatcher : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] CaughtNoteEvent _noteCaught;
    [Header("References")]
    [SerializeField] ObjectPoolController _notePoolController;
    [Header("Parameters")]
    [SerializeField] Color _defaultColor;
    [SerializeField] Color _onCatchColor;
    [SerializeField] float _transitionTime;

    SpriteRenderer _spriteRenderer;
    BoxCollider _boxCollider;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }
    public void CatchNote()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(CatchNoteTask));
    }

    private IEnumerator CatchNoteTask()
    {
        _spriteRenderer.color = _onCatchColor;
        _boxCollider.enabled = true;
        yield return new WaitForSeconds(_transitionTime);
        _spriteRenderer.color = _defaultColor;
        _boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Note>(out Note note))
        {
            float distance = Vector2.Distance(note.transform.position, this.transform.position);
            CaughtNote caughtNote = new CaughtNote(note, distance);
            _noteCaught.Raise(caughtNote);
            _notePoolController.ReturnObject(note.gameObject);
        }
    }
}

public class CaughtNote
{
    Note _note;
    float _distanceFromNoteCatcher;

    public Note note => _note;
    public float distanceFromCatcher => _distanceFromNoteCatcher;

    public CaughtNote (Note p_note, float p_distanceFromNoteCatcher)
    {
        _note = p_note;
        _distanceFromNoteCatcher = p_distanceFromNoteCatcher;
    }
}
