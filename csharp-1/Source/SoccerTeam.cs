using Codenation.Challenge.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Source
{
    class SoccerTeam
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }
        private readonly Dictionary<long, SoccerPlayer> _soccerPlayers = new Dictionary<long, SoccerPlayer>();


        public SoccerPlayer GetPlayer(long playerId)
        {
            if (HasPlayer(playerId))
                return _soccerPlayers[playerId];
            else
                throw new PlayerNotFoundException($"Jogador '{playerId}' não foi encontrado no time '{Id}'" );
        }

        public bool HasPlayer(long playerId)
        {
            return _soccerPlayers.ContainsKey(playerId);
        }

        public SoccerPlayer GetBestPlayer()
        {
            SoccerPlayer bestPlayer = _soccerPlayers.Values
                .OrderByDescending(player => player.SkillLevel)
                .ThenBy(player => player.Id)
                .First();

            return bestPlayer;
        }

        public SoccerPlayer GetHigherSalaryPlayer()
        {
            SoccerPlayer bestPlayer = _soccerPlayers.Values
                .OrderByDescending(player => player.Salary)
                .ThenBy(player => player.Id)
                .First();

            return bestPlayer;
        }
        
        public SoccerPlayer GetOlderTeamPlayer()
        {
            SoccerPlayer bestPlayer = _soccerPlayers.Values
                .OrderBy(player => player.BirtDate)
                .ThenBy(player => player.Id)
                .First();

            return bestPlayer;
        }

        public void SetCaptain(long playerId)
        {
            try
            {
                GetTeamCaptain().Capitan = false;
            }
            catch (CaptainNotFoundException) { }
            finally
            {
                _soccerPlayers[playerId].Capitan = true;
            }
        }

        public SoccerTeam(long id, string name, DateTime dateCreate, string mainShirtColor, string secondaryShirtColor)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(mainShirtColor) || String.IsNullOrEmpty(secondaryShirtColor))
            {
                throw new ArgumentNullException();
            }

            Id = id;
            Name = name;
            DateCreate = dateCreate;
            MainShirtColor = mainShirtColor;
            SecondaryShirtColor = secondaryShirtColor;
        }

        public SoccerPlayer GetTeamCaptain()
        {
            SoccerPlayer captain = _soccerPlayers.Values.FirstOrDefault(player => player.Capitan);

            if (captain is null)
                throw new CaptainNotFoundException();
            else
                return captain;
        }

        public IEnumerable<SoccerPlayer> GetTeamPlayers()
        {
            return _soccerPlayers.Values;
        }

        public void AddPlayer(SoccerPlayer player)
        {
            _soccerPlayers.Add(player.Id, player);
        }

        public bool ContainsPlayerId(long idPlayer)
        {
            return _soccerPlayers.ContainsKey(idPlayer);
        }
        
    }
}
