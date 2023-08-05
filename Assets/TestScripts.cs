using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObject;
    [SerializeField]
    private int _int;
    [SerializeField, Range(0,100) ]
    private int  _intRange;
    [SerializeField]
    private float _float;
    [SerializeField]
    private bool _bool;
    [SerializeField]
    private long _long;
    [SerializeField]
    private double _double;
    [SerializeField]
    private string _string;


}

