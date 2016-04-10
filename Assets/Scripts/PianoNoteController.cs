using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PianoNoteController : MonoBehaviour
{
    public enum NoteType
    {
        Regular,
        Bomb,
        Life
    }

    public NoteType noteType;
    public List<float> sppeds = new List<float>();
    public float speed = 0;
    private bool _isClickable = false;

    // Use this for initialization
    void Start()
    {
        speed = sppeds[Random.Range(0, 1)];
        speed += speed * GameController.instance.speedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.localPosition);
        //Debug.Log(screenPosition + "Screen height:" + Screen.height);
        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
            
            if (noteType == NoteType.Regular)
            {
                GameController.instance.hp -= 15;
                GameController.instance.BreakMultiplier();
            }
        }
            

        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("note in the target");
        _isClickable = true;
        //Destroy(other.gameObject);
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        if (_isClickable)
        {
            //Destroy(this.gameObject);
        }
    }
}
