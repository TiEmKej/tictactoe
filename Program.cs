//Variables
bool isGameOn = true;
bool isPlayerOneTurn = true;
string actuallPlayerSymbol = "0";
string[,] gameFields = new string[3,3];

//Program core
ResetGameFields();

while (isGameOn)
{
    ShowGameFieldsGrid();
    SymbolChange();
    MakeDecision();
    CheckIfPlayerWon();
}

void CheckIfPlayerWon()
{
    //TODO Win condition
}

void MakeDecision()
{
    //Function Variables
    string? chosenField = "";
    bool wrongAnswer = true;

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
    Console.WriteLine("Player '{0}' turn", actuallPlayerSymbol);
}