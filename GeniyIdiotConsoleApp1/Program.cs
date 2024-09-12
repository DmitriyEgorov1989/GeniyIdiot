using System;

namespace GeniyIdiotConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя!");

            string userName = GetUserName();

            int questionsCount = 5;

            string[] questions = GetQuestions(questionsCount);

            int[] answers = GetAnswers(questionsCount);
            do
            {
                int rightAnswerCount = 0;

                Shuffle(questions, answers);

                for (int i = 0; i < questionsCount; i++)
                {
                    Console.WriteLine("Вопрос № " + (i + 1));
                    Console.WriteLine(questions[i]);

                    int userAnswer = Convert.ToInt32(Console.ReadLine());

                    int rightAnswer = answers[i];

                    if (userAnswer == rightAnswer)
                    {
                        rightAnswerCount++;
                    }
                }
                Console.WriteLine("Количество правильных ответов: " + rightAnswerCount);

                string[] diagnosis = GetDiagnoses(diagnosesCount);

                Console.WriteLine(userName + ",ваш диагноз: " + diagnosis[rightAnswerCount]);

            } while (IsRepeat());

        }
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
        private static char nameChar;
        static string GetUserName()
        {
            string rightUserName = "";

            while (!char.IsLetter(nameChar))
            {
                rightUserName = Console.ReadLine();

                for (int i = 0; i < rightUserName.Length; i++)
                {
                    nameChar = Convert.ToChar(rightUserName[i]);

                    if (!char.IsLetter(nameChar))
                    {
                        Console.WriteLine("Повторите ввод!");
                        break;
                    }
                }
            }
            return rightUserName;
        }
        private static void Shuffle(string[] questions, int[] answers)
        {
            Random random = new Random();

            for (int i = questions.Length - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);

                string tempQuestion = questions[i];
                questions[i] = questions[randomIndex];
                questions[randomIndex] = tempQuestion;

                int tempAnswer = answers[i];
                answers[i] = answers[randomIndex];
                answers[randomIndex] = tempAnswer;
            }
        }
        private static int diagnosesCount;
        private static string[] GetDiagnoses(int diagnosesCount)
        {
            diagnosesCount = 6;
            string[] diagnosis = new string[diagnosesCount];
            diagnosis[0] = "Идиот";
            diagnosis[1] = "Кретин";
            diagnosis[2] = "Дурак";
            diagnosis[3] = "Нормальный";
            diagnosis[4] = "Талант";
            diagnosis[5] = "Гений";
            return diagnosis;
        }
        private static bool IsRepeat()
        {
            string userInput = "";

            while (userInput != "да" && userInput != "нет")
            {
                Console.WriteLine("Не хотите ли вы пройти тест снова?Ответьте Да или Нет!");
                userInput = Console.ReadLine().ToLower();
            }
            if (userInput == "да")
            {
                return true;
            }
            return false;
        }
    }
}