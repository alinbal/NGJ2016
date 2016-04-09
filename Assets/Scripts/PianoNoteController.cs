using UnityEngine;
using System.Collections;

public class PianoNoteController : MonoBehaviour
{
    public float speed = 0;
    private bool _isClickable = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.localPosition);
        //Debug.Log(screenPosition + "Screen height:" + Screen.height);
        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);

            //Debug.Log(Screen.height + "" + screenPosition);
            //Debug.Break();
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
