//Variables
bool isRoundOn = true;
bool isPlayerOneTurn = true;
string actuallPlayerSymbol = "0";
string[,] gameFields = new string[3,3];

//Program core
while (isRoundOn)
{
    ResetGameFields();
    
    while (isRoundOn)
    {
        SymbolChange();
        ShowGameFieldsGrid();
        MakeDecision();
        CheckIfPlayerWon();
    }
    AskForRestart(); 
}

void AskForRestart()
{
    while (true)
    {
        Console.WriteLine("Do you want to play again?\nYes/No: ");
        string? answer = Console.ReadLine();
        if (answer == "Yes")
        {
            isRoundOn = true;
            break;
        }
        else if (answer == "No")
        {
            break;
        }
        else
        {
            Console.WriteLine("Wrong input! Try again!");
        }
    }
}

void CheckIfPlayerWon()
{
    if (gameFields[0,0] == gameFields[0,1] && gameFields[0,1] == gameFields[0,2])
    {
        ShowGameFieldsGrid();
        Console.WriteLine("Player '{0}' won!", actuallPlayerSymbol);
        isRoundOn = false;
    }
    if (gameFields[1,0] == gameFields[1,1] && gameFields[1,1] == gameFields[1,2])
    {
        ShowGameFieldsGrid();
        Console.WriteLine("Player '{0}' won!", actuallPlayerSymbol);
        isRoundOn = false;
    }
    if (gameFields[2,0] == gameFields[2,1] && gameFields[2,1] == gameFields[2,2])
    {
        ShowGameFieldsGrid();
        Console.WriteLine("Player '{0}' won!", actuallPlayerSymbol);
        isRoundOn = false;
    }
    if (gameFields[0,0] == gameFields[1,0] && gameFields[1,0] == gameFields[2,0])
    {
        ShowGameFieldsGrid();
        Console.WriteLine("Player '{0}' won!", actuallPlayerSymbol);
        isRoundOn = false;
    }
    if (gameFields[0,1] == gameFields[1,1] && gameFields[1,1] == gameFields[2,1])
    {
        ShowGameFieldsGrid();
        Console.WriteLine("Player '{0}' won!", actuallPlayerSymbol);
        isRoundOn = false;
    }
    if (gameFields[0,2] == gameFields[1,2] && gameFields[1,2] == gameFields[2,2])
    {
        ShowGameFieldsGrid();
        Console.WriteLine("Player '{0}' won!", actuallPlayerSymbol);
        isRoundOn = false;
    }
    if (gameFields[0,0] == gameFields[1,1] && gameFields[1,1] == gameFields[2,2])
    {
        ShowGameFieldsGrid();
        Console.WriteLine("Player '{0}' won!", actuallPlayerSymbol);
        isRoundOn = false;
    }
    if (gameFields[0,2] == gameFields[1,1] && gameFields[1,1] == gameFields[2,0])
    {
        ShowGameFieldsGrid();
        Console.WriteLine("Player '{0}' won!", actuallPlayerSymbol);
        isRoundOn = false;
    }
}

void MakeDecision()
{
    //Function Variables
    string? chosenField = "";
    bool wrongAnswer = true;
    Console.WriteLine("Player '{0}' turn", actuallPlayerSymbol);
    do
    {
        //Take input from user
        Console.Write("Pick a field by choosing the number: ");
        chosenField = Console.ReadLine();

        //Check if input is any of valid characters
        switch (chosenField)
        {
            case "1":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            case "2":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            case "3":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            case "4":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            case "5":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            case "6":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            case "7":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            case "8":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            case "9":
                wrongAnswer = CheckIsFieldIsFree(wrongAnswer, chosenField);
                break;
            default: 
                break;
        }
        if (wrongAnswer)
        {
            Console.WriteLine("Wrong character or place");
        }
    } while (wrongAnswer);
    
}

bool CheckIsFieldIsFree(bool wrongAnswer, string pickedField)
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if(pickedField == gameFields[i,j]){
                gameFields[i,j] = actuallPlayerSymbol;
                return false;
            }
        }
    }
    return true;
}

void ShowGameFieldsGrid()
{
    Console.Clear();
    Console.Write("\n");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write("\t" + gameFields[i,j]);
        }
        Console.Write("\t\n\n");
    }
}

void ResetGameFields()
{
    int u = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            u++;
            gameFields[i,j] = Convert.ToString(u);
        }
    }
}

void SymbolChange()
{
    //Changes the mark for player
    if (isPlayerOneTurn)
    {
        actuallPlayerSymbol = "O";
        isPlayerOneTurn = false;
    }
    else
    {
        actuallPlayerSymbol = "X";
        isPlayerOneTurn = true;
    }
}