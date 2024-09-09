using System;

namespace GeniyIdiotConsoleApp //Цифра в конце лишняя
{
    internal class Program
    {
        private static string[] GetQuestions(int questionsCount)
        {
            string[] questions = new string[questionsCount];
            questions[0] = "Сколько будет 2  плюс 2 умноженное на 2?";
            questions[1] = "Бревно нужно распилить на 10 частей,сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев,сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса,сколько нужно минут для трех уколов?";
            questions[4] = "Пять свечей горело ,две потухли.Сколько свечей осталось?";
            return questions;
        }

        private static int[] GetAnswers(int questionsCount)
        {
            int[] answers = new int[questionsCount];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        private static string[] GetDiagnoses(int diagnosesCount)
        {
            string[] diagnosis = new string[diagnosesCount]; //Забыл использовать countDiagnoses
            diagnosis[0] = "Идиот";
            diagnosis[1] = "Кретин";
            diagnosis[2] = "Дурак";
            diagnosis[3] = "Нормальный";
            diagnosis[4] = "Талант";
            diagnosis[5] = "Гений";
            return diagnosis;
        }

        private static void Shuffle(string[] questions, int[] answers)
        {
            Random random = new Random();

            for (int i = questions.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1); //Пожалуйста без сокращений и непонятных имён переменных. https://stepik.org/lesson/1304421/step/1?unit=1319339 и https://stepik.org/lesson/1304423/step/1?unit=1319341

                string tempQuestion = questions[i];
                questions[i] = questions[j];
                questions[j] = tempQuestion;

                int tempAnswer = answers[i];
                answers[i] = answers[j];
                answers[j] = tempAnswer;
            }
        }
            static bool AnswerRepeat()
        {
            Console.WriteLine("Не хотите ли вы пройти тест снова?Ответьте Да или Нет!");
            string userEndAnswer = Console.ReadLine().ToLower();

            if (userEndAnswer == "да")
            {
                return true;
            }
            else if (userEndAnswer == "нет")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Не корректный ответ!Введите да или нет");

                return AnswerRepeat();
            }
        }
        private static void Main(string[] args)
        {

            Console.WriteLine("Введите ваше имя!");
            string userName = Console.ReadLine(); //userName, используем lowerCamelCase стиль. Про это тут https://stepik.org/lesson/1304421/step/1?unit=1319339

            int questionsCount = 5; //Звучит как номер вопроса. Количество всегда обозначается словом count. т.е. questionsCount

            string[] questions = GetQuestions(questionsCount);

            int[] answers = GetAnswers(questionsCount);

            bool restart = true;

            do
            {
                int counterRightAnswer = 0;

                Shuffle(questions, answers);

                for (int i = 0; i < questionsCount; i++)
                {
                    Console.WriteLine("Вопрос № " + (i + 1));
                    Console.WriteLine(questions[i]);

                    int userAnswer = Convert.ToInt32(Console.ReadLine());

                    int rightAnswer = answers[i];

                    if (userAnswer == rightAnswer)
                    {
                        counterRightAnswer++;
                    }
                }
                Console.WriteLine("Количество правильных ответов: " + counterRightAnswer);

                int diagnosesCount = 6; //Про наименования пременных можно посмотреть тут https://stepik.org/lesson/1304428/step/1?unit=1319346

                string[] diagnosis = GetDiagnoses(diagnosesCount);

                Console.WriteLine(userName + ",ваш диагноз: " + diagnosis[counterRightAnswer]);

                restart = AnswerRepeat();

            } while (restart == true);
        }
    }               //А эта пустота зачем? Посомтри https://stepik.org/lesson/1308716/step/1?unit=1323825}
}

