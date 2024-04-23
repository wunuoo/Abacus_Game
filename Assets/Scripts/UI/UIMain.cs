using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoSingleton<UIMain>
{
    public Button button_NextChapter;
    public Button button_SuanPan;
    public Button button_Back;

    bool suanPanMode;

    // Start is called before the first frame update
    protected override void OnStart()
    {
        EventManager.Instance.OnChapterFinish += this.Refresh;
        Refresh();
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnChapterFinish -= this.Refresh;
    }

    void Refresh()
    {
        button_NextChapter.gameObject.SetActive(ChapterManager.Instance.canGoNextChapter);
        this.button_SuanPan.gameObject.SetActive(!suanPanMode);
        this.button_Back.gameObject.SetActive(suanPanMode);
    }

    public void OnClickNextChapter()
    {
        ChapterManager.Instance.StartNewChapter();
    }

    public void OnClickSuanPan()
    {
        SceneManager.Instance.LoadScene("SuanPan");
        suanPanMode = true;
        Refresh();
    }

    public void OnClickBack()
    {
        SceneManager.Instance.LoadScene("Main");
        suanPanMode = false;
        Refresh();
    }

    public void OnClickTools()
    {
        UIManager.Instance.Show<UITools>();


    }

    public void OnClickPause()
    {
        UIManager.Instance.Show<UIPauseGame>();
    }

    public void OnClickRecord()
    {
        UIManager.Instance.Show<UIRecord>();
    }

    public void OnClickCheat()
    {
        Task task = TaskManager.Instance.currentTask;
        if (task != null)
        {
            TaskManager.Instance.CheckResult(task.results[TaskManager.Instance.resultIndex]);
        }
        
    }
}
