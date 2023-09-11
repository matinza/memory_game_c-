namespace Ex05_GameManager.Initialization
{
    using System;
    using System.Collections.Generic;
    using Ex05_Players;
    using Ex05_Players.Enums;

    internal class PlayersInitializtion
    {
        private const int k_AmountOfPlayers = 2;
        private List<Player> m_playersList = new List<Player>();

        public List<Player> PlayersList { get => m_playersList; set => m_playersList = value; }

        public PlayersInitializtion()
        {
            initializePlayers();
        }

        private void initializePlayers()
        {
            ePlayerType playerType = getTypeOfSecondPlayerFromUser();
            for (int index = 0; index < k_AmountOfPlayers; index++)
            {
                if ((index == 0) ||
                   (index == 1 && playerType == ePlayerType.Regular))
                {
                    PlayersList.Add(new RegularPlayer(getNameFromUser(index), 0));
                }
                else
                {
                    PlayersList.Add(new ComputerPlayer(0));
                }
            }
        }

        private string getNameFromUser(int i_index)
        {
            string userInput;
            ++i_index;
            do
            {
                // TODO: handle in the forms
                //Ex02_View.Draw.CustomizedClearScreen(2000);
                Console.WriteLine("Please enter the {0} name:", i_index);
                userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Invalid Input: string can not be empty!");
                }
            }
            while (string.IsNullOrEmpty(userInput));

            return userInput;
        }

        private ePlayerType getTypeOfSecondPlayerFromUser()
        {
            string userInput = string.Empty;
            ePlayerType playerType = ePlayerType.Regular;

            do
            {
                // TODO: handle in the forms
                //Ex02_View.Draw.CustomizedClearScreen(2000);
                Console.WriteLine("Do you want to play against another player or the computer?");
                Console.WriteLine("(Enter 0 - player, 1 - computer)");
                userInput = Console.ReadLine();
                if (userInput == "0" || userInput == "1")
                {
                    playerType = (int.Parse(userInput) == (int)ePlayerType.Regular) ?
                                                           ePlayerType.Regular :
                                                           ePlayerType.Computer;
                }
                else
                {
                    Console.WriteLine("Invalid input: Only the inputs 0 or 1 are allowed!");
                    userInput = string.Empty;
                }
            }
            while (userInput == string.Empty);

            return playerType;
        }
    }
}
