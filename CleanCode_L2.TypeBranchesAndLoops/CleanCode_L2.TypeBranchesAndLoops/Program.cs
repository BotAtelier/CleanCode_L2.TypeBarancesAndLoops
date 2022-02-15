// See https://aka.ms/new-console-template for more information
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Random rnd = new Random();

int secretNumberMin = 0;
int secretNumberMax = 100;

int secretNumber = rnd.Next(secretNumberMin, secretNumberMax);

Console.WriteLine("\nДобро пожаловать в игру 'Угадай число' \n ".ToUpper());
Thread.Sleep(2000);
Console.Write("Как вас зовут? ");
string? userName = Console.ReadLine();

Thread.Sleep(1000);
Console.Write($"\nПривет " + $"{userName}! \n".ToUpper()) ;

Thread.Sleep(500);
Console.WriteLine(
	$"\nЯ загадал тебе число от {secretNumberMin} до {secretNumberMax}. " +
	$"Попробуй отгадать! \n");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Для начала игры нажмите любую клавишу.");
Console.ReadLine();
Console.Clear();




bool isWin = false;

int tryNumber = 0; // кол-во попытык угадывания
while (isWin == false)
{
	int userNumber = -1;
	bool isIntNumber = false;
	do
	{
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write($"\nВведите число от {secretNumberMin} до {secretNumberMax}: ");
		string? userInput = Console.ReadLine();
		isIntNumber = int.TryParse(userInput, out userNumber);

		if (!isIntNumber)
		{
			Console.WriteLine($"Вы ввели {userInput}. Нужно ввести число от 0 до 99");
        }
        else
        {
			tryNumber++;

		}
	} while (!isIntNumber);



	if (userNumber > secretNumber)
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine($"Ваше число ({userNumber}) БОЛЬШЕ, чем загаданное");
	}
	else if (userNumber < secretNumber)
	{
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		Console.WriteLine($"Ваше число ({userNumber}) МЕНЬШЕ, чем загаданное");
	}
	else
	{
		isWin = true;
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine($"Ваше число ({userNumber}) РАВНО загаданному");

		Console.WriteLine($"\n{userName}, Вы победили!".ToUpper()); 
		Console.WriteLine($"Вы угадали число с попыток: {tryNumber}".ToUpper());
	}
}