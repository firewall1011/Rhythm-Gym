using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextIntantiator : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;
    [SerializeField] string[] hits;
    [SerializeField] string[] missDir;
    [SerializeField] string[] missNoObj;

    private void Start()
    {
        RythimGenerator.OnHit += OnHit;
        RythimGenerator.OnMissed += OnMiss;
    }

    private void OnMiss(MissType type, float points)
    {
        MakeText(type);
    }

    private void OnHit(float obj)
    {
        MakeText();
    }
    
    private void MakeText()
    {
        GameObject ins = Instantiate(textPrefab, transform);
        int index = UnityEngine.Random.Range(0, hits.Length);
        ins.GetComponent<PopUp>().Setup(hits[index]);
    }

    private void MakeText(MissType type)
    {
        GameObject ins = Instantiate(textPrefab, transform);
        if(type == MissType.NoObject)
        {
            int index = UnityEngine.Random.Range(0, missNoObj.Length);
            ins.GetComponent<PopUp>().Setup(missNoObj[index]);
        }
        else
        {
            int index = UnityEngine.Random.Range(0, missDir.Length);
            ins.GetComponent<PopUp>().Setup(missDir[index]);
        }
    }

    private void OnDisable()
    {
        RythimGenerator.OnHit -= OnHit;
        RythimGenerator.OnMissed -= OnMiss;
    }
}
