using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init() // 가상함수 자식 클래스에서 함수를 재정의 가능 이 클래스를 상속받은 친구들은 자동으로 이 함수를 불러옴.
    {
        Managers.UI.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
