using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SetPause(!isPaused);
        }
    }
    public void SetPause(bool shouldPaused)
    {
        isPaused = shouldBePaused;
        _gameObject.SetActive(shouldBePaused);
    }
}
