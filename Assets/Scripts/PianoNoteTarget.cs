using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PianoNoteTarget : MonoBehaviour
{
    public AudioSource clickSource;
    public AudioClip audioClick;
    public AudioClip noteBomb;
    public AudioClip noteLife;

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
        transform.parent.transform.localScale = new Vector3(10, 10, 1);
        //Debug.Log("Click");
        // this object was clicked - do something
        if (_currentNote != null)
        {
            var pianoNoteController = _currentNote.GetComponent<PianoNoteController>();
            var audioClip = audioClick;

            switch (pianoNoteController.noteType)
            {
                case PianoNoteController.NoteType.Bomb:
                    GameController.instance.BreakMultiplier();
                    GameController.instance.hp -= 20;
                    audioClip = noteBomb;
                    break;
                case PianoNoteController.NoteType.Life:
                    GameController.instance.hp += 10;
                    audioClip = noteLife;
                    break;
            }

            //var tweener = transform.parent.DOPunchScale(new Vector3(10.01f, 10.01f, 1), 0.5f, 1, 1);
            //tweener.OnComplete(new TweenCallback(() =>
            //{
              //  GetComponent<Collider2D>().enabled = true;
            //}));

            Destroy(_currentNote.gameObject);
            clickSource.PlayOneShot(audioClip);
            GameController.instance.score++;
        }
    }
}
