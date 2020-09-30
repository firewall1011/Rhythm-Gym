using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] private float updateSpeedSeconds = 0.5f;

    private void Start()
    {
        RythimGenerator.OnHit += Hitted;
        RythimGenerator.OnMissed += Missed;
    }

    private void Hitted(float pointsPercentage)
    {
        if (pointsPercentage > 0f && pointsPercentage <= 1)
            StartCoroutine(ChangeToPct(pointsPercentage));
        else
            bar.fillAmount = pointsPercentage;
    }

    private void Missed(MissType type, float pointsPercentage)
    {
        if (pointsPercentage > 0f && pointsPercentage <= 1)
            StartCoroutine(ChangeToPct(pointsPercentage));
        else
            bar.fillAmount = pointsPercentage;
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = bar.fillAmount;
        float timeElapsed = 0f;

        while (timeElapsed < updateSpeedSeconds)
        {
            timeElapsed += Time.deltaTime;
            bar.fillAmount = Mathf.Lerp(preChangePct, pct, timeElapsed / updateSpeedSeconds);
            yield return null;
        }

        bar.fillAmount = pct;
    }

    private void OnDisable()
    {
        RythimGenerator.OnHit -= Hitted;
        RythimGenerator.OnMissed -= Missed;
    }
}
