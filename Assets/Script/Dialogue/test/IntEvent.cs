using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;

public class IntEvent: ActionTask
{
    public int o;
    public string name;
    protected override void OnExecute()
    {
        EventCenter.Instance.EventTrigger<int>(name, o);
        // ������д�������ִ���߼�
        UnityEngine.Debug.Log("Custom Action Task executed!");

        // ִ��������󣬵��� EndAction ��ʾ�������
        EndAction(true);
    }
}
