using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CustomInspector : EditorWindow
{

    private GameObject _gameObject;
    private Vector2 _scrollPosition;
    [MenuItem("Extensions/Windows/References Inspector #g") ]
    public static void ShowMyEditor()
    {
           var window=GetWindow<CustomInspector>("CustomInspector",true);
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        _scrollPosition=EditorGUILayout.BeginScrollView(_scrollPosition);
        _gameObject = (GameObject)EditorGUILayout.ObjectField(_gameObject,typeof(GameObject),true);
        if (_gameObject != null)
        {
            if (GUILayout.Button("Save"))
                SaveChanges();

            EditorGUILayout.Space();
            foreach (MonoBehaviour monoBehaviour in _gameObject.GetComponents<MonoBehaviour>())
                if (monoBehaviour != null)
                {                    
                    var style = new GUIStyle();
                    style.fontSize = 16;
                    style.normal.textColor = Color.green;
                    style.alignment = TextAnchor.MiddleCenter;
                    EditorGUILayout.LabelField(monoBehaviour.GetType().ToString(), style);
                    EditorGUILayout.Space();
                    foreach (var t in monoBehaviour.GetType().GetFields(BindingFlags.DeclaredOnly
                    | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                    {
                        if (t.FieldType == typeof(int))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.IntField(t.Name, (int)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(float))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.FloatField(t.Name, (float)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(bool))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.Toggle(t.Name, (bool)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(long))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.LongField(t.Name, (long)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(double))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.DoubleField(t.Name, (double)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(Vector2))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.Vector2Field(t.Name, (Vector2)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(Vector2Int))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.Vector2IntField(t.Name, (Vector2Int)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(Vector3))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.Vector3Field(t.Name, (Vector3)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(Vector3Int))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.Vector3IntField(t.Name, (Vector3Int)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(Vector4))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.Vector4Field(t.Name, (Vector4)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(Quaternion))
                        {
                            var quaternion = (Quaternion)t.GetValue(monoBehaviour);
                            Vector3 vector = quaternion.eulerAngles;
                            vector = EditorGUILayout.Vector3Field(t.Name, vector);
                            quaternion = Quaternion.Euler(vector.x, vector.y, vector.z);
                            t.SetValue(monoBehaviour, quaternion);

                        }
                        else if (t.FieldType == typeof(Color))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.ColorField(t.Name, (Color)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(Bounds))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.BoundsField(t.Name, (Bounds)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(BoundsInt))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.BoundsIntField(t.Name, (BoundsInt)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(Rect))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.RectField(t.Name, (Rect)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType == typeof(RectInt))
                        {
                            t.SetValue(monoBehaviour, EditorGUILayout.RectIntField(t.Name, (RectInt)t.GetValue(monoBehaviour)));
                        }
                        else if (t.FieldType.IsEnum)
                        {
                            List<string> list = new();
                            foreach (var e in Enum.GetValues(t.FieldType))
                                list.Add(e.ToString());
                            t.SetValue(monoBehaviour, EditorGUILayout.Popup((int)t.GetValue(monoBehaviour), list.ToArray()));
                        }
                        else
                            Debug.Log(t.FieldType);
                    }

                    EditorGUILayout.Space();

                }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }

    public override void SaveChanges()
    {
        base.SaveChanges();
        if (_gameObject != null)
        {
            Debug.Log($"{this} saved successfully!!!");

            EditorUtility.SetDirty(_gameObject);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            EditorSceneManager.SaveOpenScenes();
        }
        
    }

}
