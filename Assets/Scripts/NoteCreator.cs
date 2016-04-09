using System.Collections;
using UnityEngine;

public class NoteCreator : MonoBehaviour
{
    public GameObject notePrefab;
    private float _currentTime = 0;
    public float targetTimeMin = 1;
    public float targetTimeMax = 3;

    private float targetTime = 0;

    public IEnumerator CreateNote()
    {
        var shouldInstantiate = Random.Range(0, 1) == 0;
        if (shouldInstantiate)
        {
            var note = Instantiate(notePrefab, transform.position, transform.rotation) as GameObject;
        }

        yield return null;
    }

    // Use this for initialization
    void Start()
    {
        targetTime = Random.Range(targetTimeMin, targetTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > targetTime)
        {
            _currentTime = 0;
            targetTime = Random.Range(targetTimeMin, targetTimeMax);
            //CreateNote();
        }

        //Debug.Log("_currentTime:" + _currentTime + "# targetTime:" + targetTime);
    }
}
