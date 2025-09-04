using System;
using System.Collections.Generic;

namespace TelegramBotMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = null;
            bool isNameSet = false;
            string appVersion = "1.0";
            string creationDate = "19.08.2025";
            List<string> tasks = new List<string>();

            Console.WriteLine("Добро пожаловать! Доступные команды:");
            Console.WriteLine("/start - начать работу");
            Console.WriteLine("/help - помощь");
            Console.WriteLine("/info - информация о боте");
            Console.WriteLine("/exit - выход\n");

            while (true)
            {
                Console.Write(isNameSet ? $"{userName}> " : "> ");
                string input = Console.ReadLine().Trim();
                string[] inputParts = input.Split(' ', 2);
                string command = inputParts[0].ToLower();

                switch (command)
                {
                    case "/start":
                        if (isNameSet)
                        {
                            Console.WriteLine($"Вы уже зарегистрированы как {userName}.");
                        }
                        else
                        {
                            Console.Write("Введите ваше имя: ");
                            userName = Console.ReadLine().Trim();
                            if (!string.IsNullOrEmpty(userName))
                            {
                                isNameSet = true;
                                Console.WriteLine($"Привет, {userName}! Теперь вам доступна команда /echo.");
                            }
                            else
                            {
                                Console.WriteLine("Имя не может быть пустым.");
                            }
                        }
                        break;

                    case "/help":
                        Console.WriteLine("\nДоступные команды:");
                        Console.WriteLine("/start - регистрация в боте");
                        Console.WriteLine("/help - показать эту справку");
                        Console.WriteLine("/info - информация о боте");
                        Console.WriteLine("/echo [текст] - эхо-сообщение");
                        Console.WriteLine("/addtask [описание] - добавить новую задачу");
                        Console.WriteLine("/showtasks - показать список задач");
                        Console.WriteLine("/removetask - удалить задачу по номеру");
                        Console.WriteLine("/exit - выход из программы\n");
                        break;

                    case "/info":
                        Console.WriteLine("\n=== Информация о боте ===");
                        Console.WriteLine($"Версия: {appVersion}");
                        Console.WriteLine($"Дата создания: {creationDate}");
                        Console.WriteLine("Бот для управления учебными курсами\n");
                        break;

                    case "/echo":
                        if (!isNameSet)
                        {
                            Console.WriteLine("Сначала выполните команду /start");
                        }
                        else if (inputParts.Length < 2 || string.IsNullOrWhiteSpace(inputParts[1]))
                        {
                            Console.WriteLine("Введите текст после команды: /echo [ваш текст]");
                        }
                        else
                        {
                            Console.WriteLine($"{userName}, вы сказали: {inputParts[1]}");
                        }
                        break;

                    case "/addtask":
                        if (inputParts.Length < 2 || string.IsNullOrWhiteSpace(inputParts[1]))
                        {
                            Console.WriteLine("Введите описание задачи после команды: /addtask [описание]");
                        }
                        else
                        {
                            tasks.Add(inputParts[1]);
                            Console.WriteLine($"Задача добавлена: {inputParts[1]}");
                        }
                        break;

                    case "/showtasks":
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("Список задач пуст.");
                        }
                        else
                        {
                            Console.WriteLine("\nСписок задач:");
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case "/removetask":
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("Список задач пуст. Нечего удалять.");
                            break;
                        }

                        // Показываем список задач
                        Console.WriteLine("\nСписок задач:");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tasks[i]}");
                        }

                        // Запрашиваем номер задачи для удаления
                        Console.Write("Введите номер задачи для удаления: ");
                        string inputNumber = Console.ReadLine().Trim();

                        if (int.TryParse(inputNumber, out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
                        {
                            string removedTask = tasks[taskNumber - 1];
                            tasks.RemoveAt(taskNumber - 1);
                            Console.WriteLine($"Задача удалена: {removedTask}");
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер задачи. Пожалуйста, введите корректный номер.");
                        }
                        break;

                    case "/exit":
                        Console.WriteLine($"\nДо свидания{(isNameSet ? $", {userName}" : "")}! Работа бота завершена.");
                        return;

                    default:
                        Console.WriteLine($"Неизвестная команда: {command}. Введите /help для помощи.");
                        break;
                }
            }
        }
    }
}