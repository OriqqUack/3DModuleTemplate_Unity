using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" }; //@UI_Root라는 게임 오브젝트를 찾고 없으면 만듬
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay; //화면에 꽉차게 렌더
        canvas.overrideSorting = true; //부모가 어떤 값을 가지던 sortingOrder를 가진다.

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T MakeSubItem<T>(Transform parent = null,string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");

        if (parent != null)
            go.transform.SetParent(parent);

        return Util.GetOrAddComponent<T>(go);
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name)) //매개변수로 name을 넘겨주지 않을시 T 타입과 동일시 됨.
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(Root.transform); //@UI_Root 산하로 관리하기 위한 작업

        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name)) //매개변수로 name을 넘겨주지 않을시 T 타입과 동일시 됨.
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform); //@UI_Root 산하로 관리하기 위한 작업

        return popup;
    }

    public void ClosePopupUI(UI_Popup popup) // 마지막게 아닌 중간게 없어지는 걸 막아주는 인터페이스
    {
        if (_popupStack.Count == 0)
            return;

        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup UI");
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;

    }

    public void CloseAllPopup()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

    public void Clear()
    {
        CloseAllPopup();
        _sceneUI = null;
    }
}
