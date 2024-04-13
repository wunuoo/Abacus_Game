using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIDialog : MonoBehaviour
{
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI content;
    public Image portrait;

    int index;
    int length;

    Dialog dialog;
    public void StartDialog(Dialog dialog)
    {
        this.index = 0;
        this.dialog = dialog;
        this.length = dialog.dialogNodes.Length;
        Play(dialog.dialogNodes[index]);
    }

    void Play(DialogNode node)
    {
        characterName.text = node.name.ToString();
        content.text = node.content.ToString();
        portrait.sprite = node.portrait;
    }

    public void OnClickNext()
    {
        index++;
        if(index == length)//˵���Ѿ��������һ��Ի��е����һ����
        {
            gameObject.SetActive(false);
        }
        else
        {
            Play(dialog.dialogNodes[index]);
        }
    }

    public void OnDestroy()
    {
        UIManager.Instance.DeleteInstance<UIDialog>();
    }
}