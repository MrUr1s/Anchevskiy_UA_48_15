using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts2 : MonoBehaviour
{
    [SerializeField]
    private Vector2 _vector2;
    [SerializeField]
    private Vector2Int _vector2Int;
    [SerializeField]
    private Vector3 _vector3;
    [SerializeField]
    private Vector3Int _vector3Int;
    [SerializeField]
    private Vector4 _vector4;
    [SerializeField]
    private Quaternion _quaternion;
    [SerializeField]
    private Color _color;
    [SerializeField]
    private BoundsInt _boundsInt;
    [SerializeField]
    private Bounds _bounds;
    [SerializeField]
    private RectInt _rectInt;
    [SerializeField]
    private Rect _rect;
    [SerializeField]
    private TestEnum _testEnum;
    [SerializeField]
    private int[] _arrayInt;
}

public enum TestEnum { TestEnum1, TestEnum2 };