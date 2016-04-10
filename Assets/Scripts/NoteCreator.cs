using System.Collections;
using UnityEngine;

public class NoteCreator : MonoBehaviour
{
    public GameObject notePrefab;
    public GameObject notePrefabBomb;
    public GameObject notePrefabLife;

    private float _currentTime = 0;
    public float targetTimeMin = 1;
    public float targetTimeMax = 3;

    public float _chanceLife = 0.3f;
    public float _chanceBomb = 0.4f;
    public float _changeCreateSpecialNote = 0.35f;

    private float targetTime = 0;

    public IEnumerator CreateNote()
    {
        var chosenNotePrefab = notePrefab;
        var shouldInstantiateSpecialNote = Random.Range(0, 1f) <= _changeCreateSpecialNote;
        if (shouldInstantiateSpecialNote)
        {
            //var shouldRollBomb = Random.Range(0, 1) == 0;
            //if (shouldRollBomb)
            {
                var shouldChooseNoteBomb = Random.Range(0, 1f) <= _chanceBomb;
                if (shouldChooseNoteBomb)
                {
                    chosenNotePrefab = notePrefabBomb;
                }
            }
            //else
            {
                var shouldChooseNoteLife = Random.Range(0, 1f) <= _chanceLife;
                if (shouldChooseNoteLife)
                {
                    chosenNotePrefab = notePrefabLife;
                }
            }
        }

        var shouldInstantiate = Random.Range(0, 1f) <= 0.7;
        if (shouldInstantiate)
        {
            var note = Instantiate(chosenNotePrefab, transform.position, transform.rotation) as GameObject;
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
