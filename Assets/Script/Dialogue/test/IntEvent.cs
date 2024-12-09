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
        // 在这里写你任务的执行逻辑
        UnityEngine.Debug.Log("Custom Action Task executed!");

        // 执行完任务后，调用 EndAction 表示任务结束
        EndAction(true);
    }
}
