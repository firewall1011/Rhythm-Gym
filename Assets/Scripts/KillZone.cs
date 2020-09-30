using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] RythimGenerator Generator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Generator.Missed(MissType.NoObject);
        Destroy(collision.gameObject);
    }
}
