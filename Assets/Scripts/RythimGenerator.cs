using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SwipeType{ Tap, Up, Down, Left, Right};
public enum MissType{ NoObject, WrongDirection};

public class RythimGenerator : MonoBehaviour
{
    public static Action<int> OnPointsChanged = null;
    public static Action<int> OnStateChange = null;
    public static Action<MissType, float> OnMissed;
    public static Action<float> OnHit;

    [Header("Feedbacks")]
    public MoreMountains.Feedbacks.MMFeedback OnHitfeedback;
    public MoreMountains.Feedbacks.MMFeedback OnMissfeedback;
    public MoreMountains.Feedbacks.MMFeedback OnStageUpfeedback;
    public MoreMountains.Feedbacks.MMFeedback OnGameOverfeedback;

    public Transform HitTransform = null;
    public float HitRadius = 1f;
    public KeyGenerator KeyGenerator = null;

    [Header("Points")]
    [SerializeField] private int TotalPoints = 0;
    public float MaxStagePoints = 100;
    private float PointsPercentage => TotalPoints / (float)MaxStagePoints;
    private int actualStage = 1;

    

    private void Start()
    {
        DetectInputs.OnSwipeUp += InputUp;
        DetectInputs.OnSwipeDown += InputDown;
        DetectInputs.OnSwipeLeft += InputLeft;
        DetectInputs.OnSwipeRight += InputRight;
        OnPointsChanged += StageCheck;
        OnPointsChanged += GameOverCheck;
        OnStateChange?.Invoke(actualStage);
    }

    private void GameOverCheck(int points)
    {
        if(points < 0)
        {
            OnGameOverfeedback.Play(Vector3.zero);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    private void StageCheck(int points)
    {
        if(PointsPercentage < 1)
        {
            return;
        }
        actualStage++;
        MaxStagePoints *= 1.5f;
        TotalPoints = 0;
        KeyGenerator.Speed = KeyGenerator.Speed * 1.1f;
        OnStageUpfeedback.Play(Vector3.zero);
        OnStateChange?.Invoke(actualStage);
    }

    private void InputIncome(SwipeType type)
    {
        Collider2D collision = Physics2D.OverlapCircle(HitTransform.position, HitRadius);
        if(collision == null)
        {
            Missed(MissType.NoObject);
        }
        else
        {
            Hitted(collision.GetComponent<HitKeyComponent>().hitKey, type);
            Destroy(collision.gameObject);
        }
    }

    public void Hitted(HitKey hitKey, SwipeType type)
    {
        if(hitKey.Type != type)
        {
            Missed(MissType.WrongDirection);
        }
        else
        {
            TotalPoints += hitKey.points;
            OnPointsChanged?.Invoke(TotalPoints);
            OnHit?.Invoke(PointsPercentage);
            OnHitfeedback?.Play(Vector3.zero);
        }
    }

    public void Missed(MissType type)
    {
        if(type == MissType.NoObject)
        {
            TotalPoints -= 5;
        }
        else if(type == MissType.WrongDirection)
        {
            TotalPoints -= 10;
        }
        OnPointsChanged?.Invoke(TotalPoints);
        OnMissed?.Invoke(type, PointsPercentage);
        OnMissfeedback?.Play(Vector3.zero);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(HitTransform.position, HitRadius);
    }

    private void OnDisable()
    {
        DetectInputs.OnSwipeUp -= InputUp;
        DetectInputs.OnSwipeDown -= InputDown;
        DetectInputs.OnSwipeLeft -= InputLeft;
        DetectInputs.OnSwipeRight -= InputRight;

        OnPointsChanged -= StageCheck;
        OnPointsChanged -= GameOverCheck;
    }

    private void InputUp() { InputIncome(SwipeType.Up); }
    private void InputDown() { InputIncome(SwipeType.Down); }
    private void InputLeft() { InputIncome(SwipeType.Left); }
    private void InputRight() { InputIncome(SwipeType.Right); }
}
