using UnityEngine;
using System.Collections;

public class PianoNoteTarget : MonoBehaviour
{
    public AudioSource clickSource;
    public AudioClip audioClick;
    Collider2D _currentNote;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _currentNote = other;
        other.enabled = false;
        //Debug.Log("Being hit by a note");
        GameController.instance.StartMusic();
    }

    void OnMouseDown()
    {
        //Debug.Log("Click");
        // this object was clicked - do something
        if (_currentNote!=null)
        {
            Destroy(_currentNote.gameObject);
            clickSource.PlayOneShot(audioClick);
            GameController.instance.score++;
        }
    }
}
