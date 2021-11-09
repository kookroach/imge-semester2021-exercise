using UnityEngine;
using UnityEngine.UI;
using UniRx;

[RequireComponent(typeof(Text))]
public class ScoreLabel : MonoBehaviour
{
    private Text _TextComponent; 

    private void Start()
    {
        _TextComponent = GetComponent<Text>();
        GameData.Instance.score
            .Subscribe(score => UpdateScore(score))
            .AddTo(this);
    }


    private void UpdateScore(int score)
    {
        _TextComponent.text = score.ToString();

    }
}