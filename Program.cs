//Variables
bool isGameOn = true;
bool isPlayerOneTurn = true;
string actuallPlayerSymbol;
string[,] gameFields = new string[3,3];
string[] correctAnswer = {"1","2","3","4","5","6","7","8","9"};

//Program core
ResetGameFields();

while (isGameOn)
{
    ShowGameFieldsGrid();
    SymbolChange();
    MakeDecision();
}

void MakeDecision()
{
    string? chosenField = "";
    bool wrongAnswer = true;
    do
    {
        Console.Write("Pick a field by choosing the number: ");
        chosenField = Console.ReadLine();
        foreach (var possibleAnswer in correctAnswer)
        {
            if(chosenField == possibleAnswer){
                wrongAnswer = false;
                Console.WriteLine("Wrong character");
            }
        }
    } while (wrongAnswer);
    
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
    if (isPlayerOneTurn)
    {
        actuallPlayerSymbol = "O";
    }
    else
    {
        actuallPlayerSymbol = "X";
    }
    Console.WriteLine("Player '{0}' turn", actuallPlayerSymbol);
}