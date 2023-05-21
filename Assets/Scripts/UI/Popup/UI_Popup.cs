using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init() // �����Լ� �ڽ� Ŭ�������� �Լ��� ������ ���� �� Ŭ������ ��ӹ��� ģ������ �ڵ����� �� �Լ��� �ҷ���.
    {
        Managers.UI.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }
}
