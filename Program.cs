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
        CheckIfAnyPlaceClear();
    }
    AskForRestart(); 
}

void CheckIfAnyPlaceClear()
{
    if(isRoundOn == false)
    {
        return;
    }
    bool noDraw = false;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if(gameFields[i,j] != "X" && gameFields[i,j] != "O")
            {
                noDraw = true;
            }
        }
    }
    isRoundOn = noDraw;
    ShowGameFieldsGrid();
    Console.WriteLine("Draw!");
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
    bool wrongAnswer = true;
    string? pickedField;
    int fieldNumber;
    Console.WriteLine("Player '{0}' turn", actuallPlayerSymbol);
    
    do
    {
        //Take input from user
        Console.Write("Pick a field by choosing the number: ");
        pickedField = Console.ReadLine();
        
        //Check if input is any of valid characters
        if (int.TryParse(pickedField, out fieldNumber))
        {
            if (fieldNumber >= 1 && fieldNumber <= 9)
            {
                wrongAnswer = CheckIsFieldIsFree(Convert.ToString(fieldNumber));
            }
            else
            {
                Console.WriteLine("Value is to big!");
            }
        }
        else
        {
            Console.WriteLine("Wrong char used!");
        }
    } while (wrongAnswer);
    
}

bool CheckIsFieldIsFree(string pickedField)
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
    Console.WriteLine("Choosen field is occupied");
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
            if(gameFields[i,j] == "O")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (gameFields[i,j] == "X")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write("\t" + gameFields[i,j]);
        }
        Console.Write("\t\n\n");
    }
    Console.ForegroundColor = ConsoleColor.Gray;
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