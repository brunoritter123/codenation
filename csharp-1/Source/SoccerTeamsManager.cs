using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        
        private readonly Dictionary<long, SoccerTeam> _soccerTeams = new Dictionary<long, SoccerTeam>();

        public SoccerTeamsManager()
        {
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            
            if (_soccerTeams.ContainsKey(id))
            {
                throw new UniqueIdentifierException($"Já existe um time com o ID '{id}'.");
            }
            else
            {
                var newTeam = new SoccerTeam(id, name, createDate, mainShirtColor, secondaryShirtColor);
                _soccerTeams.Add(id, newTeam);
            }
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            foreach (var teamItem in _soccerTeams.Values)
            {
                if (teamItem.ContainsPlayerId(id))
                {
                    throw new UniqueIdentifierException($"Já existe um jogador com o ID '{id}'.");
                }
            }

            SoccerTeam team;
            if (!_soccerTeams.TryGetValue(teamId, out team))
                throw new TeamNotFoundException($"Não foi encontrado o time: {teamId}");
            else
            {
                var newPlayer = new SoccerPlayer(id, teamId, name, birthDate, skillLevel, salary);
                team.AddPlayer(newPlayer);
            }
        }

        public void SetCaptain(long playerId)
        {
            SoccerPlayer newCaptain = GetPlayer(playerId);
            _soccerTeams[newCaptain.TeamId].SetCaptain(playerId);
        }

        public long GetTeamCaptain(long teamId)
        {
            SoccerTeam team;
            if (!_soccerTeams.TryGetValue(teamId, out team))
                throw new TeamNotFoundException($"Não foi encontrado o time: {teamId}");
            else
                return team.GetTeamCaptain().Id;
        }

        public string GetPlayerName(long playerId)
        {
            SoccerPlayer player = GetPlayer(playerId);
            return player.Name;
        }

        public string GetTeamName(long teamId)
        {
            SoccerTeam team;
            if (!_soccerTeams.TryGetValue(teamId, out team))
                throw new TeamNotFoundException($"Não foi encontrado o time: {teamId}");
            else
                return team.Name;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            SoccerTeam team;
            if (!_soccerTeams.TryGetValue(teamId, out team))
                throw new TeamNotFoundException($"Não foi encontrado o time: {teamId}");
            else
                return team.GetTeamPlayers()
                .OrderBy(player => player.Id)
                .Select(player => player.Id)
                .ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            SoccerTeam team;
            if (!_soccerTeams.TryGetValue(teamId, out team))
                throw new TeamNotFoundException($"Não foi encontrado o time: {teamId}");
            else
                return team.GetBestPlayer().Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            SoccerTeam team;
            if (!_soccerTeams.TryGetValue(teamId, out team))
                throw new TeamNotFoundException($"Não foi encontrado o time: {teamId}");
            else
                return team.GetOlderTeamPlayer().Id;
        }

        public List<long> GetTeams()
        {
            return _soccerTeams.Values
                .OrderBy(team => team.Id)
                .Select(team => team.Id)
                .ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            SoccerTeam team;
            if (!_soccerTeams.TryGetValue(teamId, out team))
                throw new TeamNotFoundException($"Não foi encontrado o time: {teamId}");
            else
                return team.GetHigherSalaryPlayer().Id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            SoccerPlayer player = GetPlayer(playerId);
            return player.Salary;
        }

        public List<long> GetTopPlayers(int top)
        {
            List<SoccerPlayer> players = new List<SoccerPlayer>();
            foreach (var team in _soccerTeams.Values)
            {
                players.AddRange(team.GetTeamPlayers());
            }

            return players
                .OrderByDescending(player => player.SkillLevel)
                .Select(player => player.Id)
                .Take(top)
                .ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            SoccerTeam team;
            SoccerTeam visitorTeam;
            if (!_soccerTeams.TryGetValue(teamId, out team) || !_soccerTeams.TryGetValue(visitorTeamId, out visitorTeam))
                throw new TeamNotFoundException();

            if (team.MainShirtColor == visitorTeam.MainShirtColor)
                return visitorTeam.SecondaryShirtColor;
            else
                return visitorTeam.MainShirtColor;
        }

        private SoccerPlayer GetPlayer(long playerId)
        {
            foreach (var team in _soccerTeams.Values)
            {
                if ( team.HasPlayer(playerId))
                    return team.GetPlayer(playerId);
            }

            throw new PlayerNotFoundException();
        }

    }
}
