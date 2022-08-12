using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : Command
{
    [SerializeField] private string _sceneToload;
    public LoadSceneCommand(string sceneToLoad)
    {
        _sceneToload = sceneToLoad;
    }

    public async Task Execute()
    {
        var fadeView = ServiceLocator.Instance.GetService<FadeView>();
        fadeView.Show();

        while (!fadeView.IsShowEnded())
        {
            await Task.Yield();
        }

        await LoadScene(_sceneToload);
        fadeView.Hidde();

    }


    private async Task LoadScene(string sceneToLoad)
    {
        var loadSceneAsync = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!loadSceneAsync.isDone)
        {
            await Task.Yield();
        }

        await Task.Yield();
    }
}
