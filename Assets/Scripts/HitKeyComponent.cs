using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class HitKeyComponent : MonoBehaviour
{
    public HitKey hitKey;

    private SVGImage _renderer    = null;
    private CircleCollider2D _collider  = null;
    private Rigidbody2D _rigidbody      = null;
    private float _radius   = 0f;
    private float _speed    = 0f;
    private bool _isInitialized = false;

    public void Initialize(HitKey hitKey, float radius, float speed)
    {
        _radius = radius;
        _speed = speed;
        this.hitKey = hitKey;

        _renderer = gameObject.GetComponent<SVGImage>();
        _renderer.sprite = hitKey.Sprite;

        _collider = gameObject.AddComponent<CircleCollider2D>();
        _collider.radius = radius;

        _rigidbody = gameObject.AddComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
        _rigidbody.isKinematic = true;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        _rigidbody.velocity = new Vector2(-_speed, 0f);

        _isInitialized = true;
    }

}