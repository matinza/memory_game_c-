namespace Ex05_Players
{
    using System;

    public class RegularPlayer : Player
    {
        public RegularPlayer(string i_Name,
                             int i_AmountOfPoints)
        {
            Name = i_Name;
            AmountOfPoints = i_AmountOfPoints;
        }
    }
}
