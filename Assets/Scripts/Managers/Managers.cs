using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource {  get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }
    static void Init()
    {
        if(s_instance == null)
        {
            GameObject GO = GameObject.Find("@Managers");
            if (GO == null)
            {
                GO = new GameObject { name = "@Managers" };
                GO.AddComponent<Managers>();
            }
            DontDestroyOnLoad(GO);
            s_instance = GO.GetComponent<Managers>();
        }
    }
}
