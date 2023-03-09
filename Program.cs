// Angabe: https://github.com/Teaching-HTL-Leonding/text-adventure-David-Pogner

string NameOfUser;
string MoveInIntroScene;
string MoveInHuntedRoom;
string MoveInShowShadowFigureRoom;
string MoveInCameraSceneRoom;
string MoveInShowSkeletonsRoom;
string MoveInDeadEndWeaponWall;
string MoveInStrangerCreatureRoom;
string MoveInFirstDeadEndWall;
string MoveInSecondDeadEndWall;
bool WeaponCollectet = false;
bool GoulIsAlive = true;

Greeting();
IntroScene();

void Greeting()
{
    Console.Clear();
    System.Console.WriteLine("Welcome to the Adventure Game!");
    System.Console.WriteLine("==============================");
    System.Console.WriteLine("As an avid traveler, you have decided to visit the Catacombs of Paris.");
    System.Console.WriteLine("However, during your exploration, you find yourself lost.");
    System.Console.WriteLine("You can choose to walk in multiple directions to find a way out.");
    System.Console.WriteLine("Let's start with your name: ");
    NameOfUser = Console.ReadLine()!;
    System.Console.WriteLine($"Good Luck {NameOfUser}");
}

void IntroScene()
{
    System.Console.WriteLine("You are at a crossroads, and you can choose to go down any of the four hallways. Where would you like to go?");
    System.Console.WriteLine("Options: north/east/south/west");
    MoveInIntroScene = Console.ReadLine()!;

    switch (MoveInIntroScene)
    {
        case "north": FirstDeadEndWall(); break;
        case "east": ShowSkeletons(); break;
        case "south": HauntedRoom(); break;
        case "west": ShowShadowFigure(); break;
        default: InValidInput(); break;
    }
}

void ShowShadowFigure()
{
    System.Console.WriteLine("You see a dark shadowy figure appear in the distance. You are creeped out. Where would you like to go?");

    System.Console.WriteLine("Options: north/east/south");
    MoveInShowShadowFigureRoom = Console.ReadLine()!;

    switch (MoveInShowShadowFigureRoom)
    {
        case "north": CameraScene(); break;
        case "south": SecondDeadEndWall(); break;
        case "east": IntroScene(); break;
        default: InValidInput(); break;
    }
}

void CameraScene()
{

    System.Console.WriteLine("You see a camera that has been dropped on the ground. Someone has been here recently. Where would you like to go?");

    System.Console.WriteLine("Options: north/south");
    MoveInCameraSceneRoom = Console.ReadLine()!;

    switch (MoveInCameraSceneRoom)
    {
        case "north": Exit(); break;
        case "south": ShowShadowFigure(); break;
        default: InValidInput(); break;
    }

}

void HauntedRoom()
{
    System.Console.WriteLine("You hear strange voices. You think you have awoken some of the dead. Where would you like to go?");

    System.Console.WriteLine("Options: north/east/west");
    MoveInHuntedRoom = Console.ReadLine()!;

    switch (MoveInHuntedRoom)
    {
        case "north": IntroScene(); break;
        case "east": Exit(); break;
        case "west": Dead(); break;
        default: InValidInput(); break;
    }
}

void ShowSkeletons()
{
    System.Console.WriteLine("You see a wall of skeletons as you walk into the room. Someone is watching you. Where would you like to go?");
    System.Console.WriteLine("Options: north/east/west");
    MoveInShowSkeletonsRoom = Console.ReadLine()!;

    switch (MoveInShowSkeletonsRoom)
    {
        case "north": DeadEndWeaponWall(); break;
        case "east": StrangerCreature(); break;
        case "west": IntroScene(); break;
        default: InValidInput(); break;
    }
}

void StrangerCreature()
{
    if (GoulIsAlive == true)
    {
        if (WeaponCollectet == false)
        {
            Console.Write("Multiple goul-like creatures start emerging as you enter the room. ");
            Dead();
        }
        else
        {
            System.Console.WriteLine("A strange Goul-like creature has appeared. You can either run or fight it. What would you like to do?");
            Console.WriteLine("Options: fight/run");
            string ChoiceForGouldFight = Console.ReadLine()!;

            if (ChoiceForGouldFight == "fight")
            {
                GoulIsAlive = false;
                Console.WriteLine("You won against the Goul");
                Console.WriteLine("Where do you want to go?");
                Console.WriteLine("Options: south/west");
                MoveInStrangerCreatureRoom = Console.ReadLine()!;

                switch (MoveInStrangerCreatureRoom)
                {
                    case "west": ShowSkeletons(); break;
                    case "south": Exit(); break;
                    default: InValidInput(); break;
                }
            }
            else
            {
                ShowSkeletons();
            }
        }
    }
    else
    {
        Console.WriteLine("You see the Goul-like creature that you killed earlier. What a relief! Where would you like to go?");
        Console.WriteLine("Options: south/west");
        MoveInStrangerCreatureRoom = Console.ReadLine()!;

        switch(MoveInStrangerCreatureRoom)
        {
            case "south": Exit(); break;
            case "west": ShowSkeletons(); break;
            default: InValidInput(); break;
        }
    }
}

void DeadEndWeaponWall()
{
    WeaponCollectet = true;
    System.Console.WriteLine("You find that this door opens into a wall. You open some of the drywall to discover a knife. ");
    Console.WriteLine("Options: east/west");
    MoveInDeadEndWeaponWall = Console.ReadLine()!;

    switch (MoveInDeadEndWeaponWall)
    {
        case "east": StrangerCreature(); break;
        case "west": IntroScene(); break;
        default: InValidInput(); break;
    }
}

void FirstDeadEndWall()
{
    System.Console.WriteLine("You find that this door opens into a wall.");
    Console.WriteLine("Options: east/south/west");
    MoveInFirstDeadEndWall = Console.ReadLine()!;

    switch (MoveInFirstDeadEndWall)
    {
        case "east": ShowSkeletons(); break;
        case "south": HauntedRoom(); break;
        case "west": ShowShadowFigure(); break;
        default: InValidInput(); break;
    }
}

void SecondDeadEndWall()
{
    System.Console.WriteLine("You find that this door opens into a wall.");
    Console.WriteLine("Options: north/east");
    MoveInSecondDeadEndWall = Console.ReadLine()!;

    switch (MoveInSecondDeadEndWall)
    {
        case "north": CameraScene(); break;
        case "east": IntroScene(); break;

        default: InValidInput(); break;
    }
}

void Exit()
{
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine("You made it! You've found an exit."); 
    Console.ResetColor();
}

void Dead() 
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("You died!");
    Console.ResetColor();
}

void InValidInput() { Console.WriteLine("Invalid Input!"); }