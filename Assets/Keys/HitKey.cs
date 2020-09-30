using UnityEngine;

[CreateAssetMenu(fileName = "key", menuName = "HitKey", order = 1)]
public class HitKey : ScriptableObject
{
    public SwipeType Type;
    public Sprite Sprite;
    public int points;
}
