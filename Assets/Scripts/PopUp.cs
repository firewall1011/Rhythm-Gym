using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] float lifeTime = 1f;
    [SerializeField] float speed = 1f;
    [SerializeField] TMPro.TMP_Text _textMeshPro = null;

    private Vector3 _translateDir = Vector3.zero;
    private bool _started = false;

    public void Setup(string text)
    {
        _textMeshPro.SetText(text);
        _translateDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        Destroy(gameObject, lifeTime);
        _started = true;
    }

    private void Update()
    {
        if (!_started)
        {
            return;
        }

        transform.Translate(_translateDir * speed * Time.deltaTime);
        _textMeshPro.alpha = Mathf.Lerp(_textMeshPro.alpha, 0f, speed * Time.deltaTime);
    }

}
