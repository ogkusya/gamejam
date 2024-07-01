using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private List<KeyValuePair<string, string>> Dialog1Dict = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("Морозко", "Тепло ли тебе, девица? Тепло ли тебе, красная?"),
        new KeyValuePair<string, string>("Настенька", "Тепло, тепло, Морозушко!"),
        new KeyValuePair<string, string>("Морозко", "Что же ты, милая, в лесу одна-одинешенька делаешь?"),
        new KeyValuePair<string, string>("Настенька", "Ищу я дорогу домой. Прошу тебя, дай мне сил пройти этот путь."),
        new KeyValuePair<string, string>("Морозко", "Помогу я тебе, добрая душа, но прежде тебе предстоит пройти испытания. Видишь ли ты ту вершину опушки, белоснежной шапкой покрытую?"),
        new KeyValuePair<string, string>("Настенька", "Вижу, батюшка, вижу."),
        new KeyValuePair<string, string>("Морозко", "Заберись на ту вершину, докажи силу духа и стойкость свою. Если справишься — награду щедрую получишь."),
        new KeyValuePair<string, string>("Настенька", "Приму я твое испытание, Морозушко. Постараюсь не подвести тебя.")
    };

    private List<KeyValuePair<string, string>> Dialog2Dict = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("Настенька", "Вот я и на вершине, Морозушко. Твое испытание преодолела."),
        new KeyValuePair<string, string>("Морозко", "Вижу, славно ты с моей проверкой справилась. Вот тебе мой подарок — двойной прыжок. С ним горы и долы легче будет преодолевать."),
        new KeyValuePair <string, string>("Настенька", "Благодарю тебя, батюшка. Твой дар приму с великой радостью."),
        new KeyValuePair <string, string>("", "Нажмите \"SPACE\" дважды для двойного прыжка. С его помощью можно прыгать выше."),
        new KeyValuePair <string, string>("Морозко", "Добрая ты, Настенька, сильная. Испытание первое с честью прошла. Теперь могу я поручить тебе следующее задание. Пройти тебе нужно к подножию гор, сквозь снежную бурю, свирепую и беспощадную."),
        new KeyValuePair <string, string>("Настенька", "Хорошо, Морозушка. Готова я, хоть снег и ветер страшат меня."),
        new KeyValuePair <string, string>("Морозко", "Будь крепка духом, девица. Преодолеешь вьюгу — награжу тебя по заслуге.")
    };

    private List<KeyValuePair<string, string>> Dialog3Dict = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("Настенька", "Вот я и у подножия гор, Морозушко. Снежную бурю преодолела, силы все свои вложила."),
        new KeyValuePair<string, string>("Морозко", "Умница, девица. Вот мой дар — рывок. С ним не страшны тебе пропасти и напасти."),
        new KeyValuePair <string, string>("Настенька", "Спасибо, батюшка. Приму с благодарностью твой ценный дар."),
        new KeyValuePair <string, string>("", "Нажмите \"SHIFT\" для рывка вперед. С его помощью можно прыгнуть дальше на земле и в воздухе."),
        new KeyValuePair <string, string>("Морозко", "Милая, отважная Настенька, справилась ты со свирепой стихией. Последнее испытание я для тебя приготовил. Заберись на вершину самой высокой  горы, да принеси мне мой посох, что там покоится."),
        new KeyValuePair <string, string>("Настенька", "Пойду, Морозушко. Посох твой отыщу и принесу.")
    };

    private List<KeyValuePair<string, string>> Dialog4Dict = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("Настенька", "Справилась я с последним твоим испытанием, Морозушко. Принесла твой посох с самой вершины самой высокой горы."),
        new KeyValuePair<string, string>("Морозко", "Молодец, Настенька, преодолела ты все невзгоды — и непогоду, и высоты. Теперь это твой посох. Уверен я, что использовать его ты будешь с умом и по справедливости."),
        new KeyValuePair <string, string>("Настенька", "Благодарю тебя, батюшка, за такой щедрый подарок."),
        new KeyValuePair <string, string>("", "Нажмите \"LMB\" для совершения атаки посохом. С его помощью можно сражаться с агрессивными существами."),
        new KeyValuePair <string, string>("Морозко", "Посох этот поможет тебе справиться с недругами, но чтобы раскрыть его полную силу, к мудрой Бабе Яге за помощью обратиться придется. Найти её можно в избушке среди чащи лесной, что за горами простирается."),
        new KeyValuePair <string, string>("Настенька", "Спасибо тебе за все, Морозушко, за доверие и дары твои. Пойду я на поиски Бабы Яги за мудростью и знаниями."),
        new KeyValuePair <string, string>("", "Но это уже совсем другая история...")
    };

    //[SerializeField] private GameObject mainCharacter;
    //[SerializeField] private CharacterStateMachine mainCharacterSM;

    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text mainText;
    [SerializeField] private TMP_Text nameCharacter;
    [SerializeField] private Image imageNastya;
    [SerializeField] private Image imageMoroz;
    [SerializeField] private Image imageDefault;

    private bool _isUseDialog = false;
    private List<KeyValuePair<string, string>> _currentDialog = null;

    private int _currentIndex = -1;
    private int _newIndex = -1;

    private bool _isWasDialog2 = false;
    private bool _isWasDialog3 = false;

    private void Start()
    {
        StartDialog(Dialog1Dict);
    }

    private void Update()
    {
        if (_isUseDialog && _currentDialog != null && _newIndex == _currentIndex + 1 && _newIndex < _currentDialog.Count)
        {
            _currentIndex = _newIndex;

            string name = _currentDialog[_currentIndex].Key;
            nameCharacter.text = name;

            switch (name)
            {
                case "Морозко":
                    imageMoroz.enabled = true;
                    imageNastya.enabled = false;
                    imageDefault.enabled = false;
                    break;
                case "Настенька":
                    imageMoroz.enabled = false;
                    imageNastya.enabled = true;
                    imageDefault.enabled = false;
                    break;
                default:
                    imageMoroz.enabled = false;
                    imageNastya.enabled = false;
                    imageDefault.enabled = true;
                    break;
            }

            mainText.text = _currentDialog[_currentIndex].Value;
        }

        if (CharacterStateMachine.IsDoubleJumpExist && !_isWasDialog2)
        {
            StartDialog(Dialog2Dict);
            _isWasDialog2 = true;
        }

        if (CharacterStateMachine.IsDashExist && !_isWasDialog3)
        {
            StartDialog(Dialog3Dict);
            _isWasDialog3 = true;
        }
    }

    private void StartDialog(List<KeyValuePair<string, string>> dialog)
    {
        _currentDialog = dialog;
        _isUseDialog = true;
        _currentIndex = -1;
        _newIndex = 0;
        dialogPanel.SetActive(true);
    }

    public void ContinueDialog()
    {
        _newIndex++;

        if (_newIndex >= _currentDialog.Count)
        {
            dialogPanel.SetActive(false);
        }
    }
}
