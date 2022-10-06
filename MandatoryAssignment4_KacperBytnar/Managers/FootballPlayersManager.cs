using Assignment1_KacperBytnar;

namespace MandatoryAssignment4_KacperBytnar.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer> FootballPlayers = new List<FootballPlayer>
        {
            new FootballPlayer(_nextId++, "Dawid", 12, 9),
            new FootballPlayer(_nextId++, "Michael", 8, 13),
            new FootballPlayer(_nextId++, "Eustachy", 2, 19),
            new FootballPlayer(_nextId++, "Mohammed", 9, 96),
        };

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(FootballPlayers);
        }

        public FootballPlayer GetById(int id)
        {
            return FootballPlayers.Find(FootballPlayer => FootballPlayer.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newFootballPlayer)
        {
            newFootballPlayer.Id = _nextId++;
            FootballPlayers.Add(newFootballPlayer);
            return newFootballPlayer;
        }

        public FootballPlayer Update(int id, FootballPlayer updatedFootballPlayer)
        {
            FootballPlayer FootballPlayer = FootballPlayers.Find(FootballPlayer1 => FootballPlayer1.Id == id);
            if (FootballPlayer == null) return null;
            FootballPlayer.Name = updatedFootballPlayer.Name;
            FootballPlayer.Age = updatedFootballPlayer.Age;
            FootballPlayer.ShirtNumber = updatedFootballPlayer.ShirtNumber;

            return FootballPlayer;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer FootballPlayer = FootballPlayers.Find(FootballPlayer1 => FootballPlayer1.Id == id);
            if (FootballPlayer == null) return null;
            FootballPlayers.Remove(FootballPlayer);
            return FootballPlayer;
        }

    }
}
