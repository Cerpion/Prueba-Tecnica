using System.Collections;
using System.Threading.Tasks;

public static class TaskExtension
{
    public static async void WrapErros(this Task task)
    {
        await task;
    }

    public static IEnumerator AsCorrutine(this Task task)
    {
        while (!task.IsCompleted)
        {
            yield return null;
        }

        if (task.IsFaulted)
        {
            throw task.Exception;
        }
    }
}
