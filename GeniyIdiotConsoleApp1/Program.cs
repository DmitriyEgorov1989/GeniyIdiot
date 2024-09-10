using System;

namespace GeniyIdiotConsoleApp
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
            string[] diagnosis = new string[diagnosesCount];
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
                int randomIndex = random.Next(i + 1); //j обычно используется во вложенных циклах. В данном случае лучше назвать переменную random, читаемость повысится.

                string tempQuestion = questions[i];
                questions[i] = questions[randomIndex];
                questions[randomIndex] = tempQuestion;

                int tempAnswer = answers[i];
                answers[i] = answers[randomIndex];
                answers[randomIndex] = tempAnswer;
            }
        }

        static bool RepeatQuestions() //Почитай про именование методов возвращающих bool. https://stepik.org/lesson/1308720/step/1?unit=1323829
        {
            Console.WriteLine("Не хотите ли вы пройти тест снова?Ответьте Да или Нет!");
            string userEndAnswer = Console.ReadLine().ToLower(); //End излишнее.
			// else излишне, т.е. просто if и последний else вообще можно убрать. Вот тут подробнее https://stepik.org/lesson/1404526/step/1?unit=1421899
            if (userEndAnswer == "да")
            {
                return true;
            }
             if (userEndAnswer == "нет") 
            {
                return false;
            }
           
                Console.WriteLine("Не корректный ответ!Введите да или нет");

                return RepeatQuestions(); // Вот так делать ненадо. лучше сделать перед условиями if цикл while(userEndAnswer != "да" && userEndAnswer != "нет"). 
            }
        private static void Main(string[] args)
        {

            Console.WriteLine("Введите ваше имя!");
            string userName = Console.ReadLine();

            int questionsCount = 5;

            string[] questions = GetQuestions(questionsCount);

            int[] answers = GetAnswers(questionsCount);

            

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

                int diagnosesCount = 6;

                string[] diagnosis = GetDiagnoses(diagnosesCount);

                Console.WriteLine(userName + ",ваш диагноз: " + diagnosis[counterRightAnswer]);


            } while (RepeatQuestions()); //Смысла в переменной restart нет. Можно прям так while (AnswerRepeat())
        }
    }
}

