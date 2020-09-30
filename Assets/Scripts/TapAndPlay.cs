using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapAndPlay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene(1);
        }
#else
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            SceneManager.LoadScene(1);
        }
#endif
    }
}
