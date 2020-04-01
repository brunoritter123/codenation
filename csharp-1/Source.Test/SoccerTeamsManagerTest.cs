using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManagerTest
    {      
        [Fact]
        public void Should_Be_Unique_Ids_For_Teams()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            Assert.Throws<UniqueIdentifierException>(() =>
                manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2"));
        }
 
        [Fact]
        public void Should_Be_Valid_Player_When_Set_Captain()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);
            manager.AddPlayer(2, 1, "Jogador 1", DateTime.Today, 0, 0);
            manager.SetCaptain(1);
            manager.SetCaptain(2);

            Assert.Equal(2, manager.GetTeamCaptain(1));

            Assert.Throws<PlayerNotFoundException>(() =>
                manager.SetCaptain(3));
        }

        [Fact]
        public void Should_Ensure_Sort_Order_When_Get_Team_Players()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var playersIds = new List<long>() {15, 2, 33, 4, 13};
            for(int i = 0; i < playersIds.Count(); i++)
                manager.AddPlayer(playersIds[i], 1, $"Jogador {i}", DateTime.Today, 0, 0);

            playersIds.Sort();
            Assert.Equal(playersIds, manager.GetTeamPlayers(1));
        }

        [Theory]
        [InlineData("10,20,300,40,50", 2)]
        [InlineData("50,240,3,1,50", 1)]
        [InlineData("10,22,24,3,24", 2)]
        public void GetBestTeamPlayerTeste(string skills, int bestPlayerId)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var skillsLevelList = skills.Split(',').Select(x => int.Parse(x)).ToList();
            for(int i = 0; i < skillsLevelList.Count(); i++)
                manager.AddPlayer(i, 1, $"Jogador {i}", DateTime.Today, skillsLevelList[i], 0);

            Assert.Equal(bestPlayerId, manager.GetBestTeamPlayer(1));
        }

        [Theory]
        [InlineData("Azul;Vermelho", "Azul;Amarelo", "Amarelo")]
        [InlineData("Azul;Vermelho", "Amarelo;Laranja", "Amarelo")]
        [InlineData("Azul;Vermelho", "Azul;Vermelho", "Vermelho")]
        public void Should_Choose_Right_Color_When_Get_Visitor_Shirt_Color(string teamColors, string visitorColors, string visitorMatchColor)
        {
            long teamId = 1;
            long visitorTeamId = 2;
            var teamColorList = teamColors.Split(";");
            var visitorColorList = visitorColors.Split(";");

            var manager = new SoccerTeamsManager();
            manager.AddTeam(teamId, $"Time {teamId}", DateTime.Now, teamColorList[0], teamColorList[1]);
            manager.AddTeam(visitorTeamId, $"Time {visitorTeamId}", DateTime.Now, visitorColorList[0], visitorColorList[1]);

            Assert.Equal(visitorMatchColor, manager.GetVisitorShirtColor(teamId, visitorTeamId));
        }
        [Theory]
        [InlineData(1, 3)]
        [InlineData(3, 1)]
        [InlineData(3, 3)]
        public void GetVisitorShirtColor_Time_Nao_Encontrado(long teamId, long visitorTeamId)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "amarelo", "azul");
            manager.AddTeam(2, "Time 2", DateTime.Now, "vermelho", "verde");

            Assert.Throws<TeamNotFoundException>(() =>
                manager.GetVisitorShirtColor(teamId, visitorTeamId));
        }

        [Theory]
        [InlineData(null, "amarelo", "azul")]
        [InlineData("NomeTime", null, "azul")]
        [InlineData("NomeTime", "amarelo", null)]
        [InlineData("", "amarelo", "azul")]
        [InlineData("NomeTime", "", "azul")]
        [InlineData("NomeTime", "amarelo", "")]
        public void AddTeam_Campos_Obrigatorios(string name, string corUniformePrincipal, string corUniformeSecundario)
        {
            var manager = new SoccerTeamsManager();
            Assert.Throws<ArgumentNullException>(() =>
                manager.AddTeam(1, name, DateTime.Now, corUniformePrincipal, corUniformeSecundario));
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void AddPlayer_Campos_Obrigatorios(string name)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            Assert.Throws<ArgumentNullException>(() =>
                manager.AddPlayer(1, 1, name, DateTime.Today, 0, 0));
        }

        [Fact]
        public void AddPlayer_Identificador_Utilizado_Ja_Existe()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador", DateTime.Today, 0, 0);

            Assert.Throws<UniqueIdentifierException>(() =>
                manager.AddPlayer(1, 1, "Jogador", DateTime.Today, 0, 0));
        }

        [Fact]
        public void AddPlayer_Time_Nao_Existe()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            Assert.Throws<TeamNotFoundException>(() =>
                manager.AddPlayer(1, 2, "Jogador", DateTime.Today, 0, 0));
        }

        [Fact]
        public void GetTeamCaptain_Time_Nao_Existe()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);
            manager.SetCaptain(1);

            Assert.Throws<TeamNotFoundException>(() =>
                manager.GetTeamCaptain(2));
        }

        [Fact]
        public void GetTeamCaptain_Capitao_Nao_Informado()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);

            Assert.Throws<CaptainNotFoundException>(() =>
                manager.GetTeamCaptain(1));
        }

        [Fact]
        public void GetPlayerName_Jogador_Nao_Encontrado()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);

            Assert.Throws<PlayerNotFoundException>(() =>
                manager.GetPlayerName(2));
        }
        [Fact]
        public void GetTeamName_Jogador_Nao_Encontrado()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            Assert.Throws<TeamNotFoundException>(() =>
                manager.GetTeamName(2));
        }

        [Fact]
        public void GetTeamPlayers_Time_Nao_Encontrado()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);

            Assert.Throws<TeamNotFoundException>(() =>
                manager.GetTeamPlayers(2));
        }
        [Fact]
        public void GetPlayerSalary_Jogador_Nao_Encontrado()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);

            Assert.Throws<PlayerNotFoundException>(() =>
                manager.GetPlayerSalary(2));
        }

        [Fact]
        public void GetBestTeamPlayer_Time_Nao_Encontrado()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);

            Assert.Throws<TeamNotFoundException>(() =>
                manager.GetBestTeamPlayer(2));
        }

        [Fact]
        public void GetOlderTeamPlayer_Time_Nao_Encontrado()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);

            Assert.Throws<TeamNotFoundException>(() =>
                manager.GetOlderTeamPlayer(2));
        }

        [Fact]
        public void GetTeams_Ordem_IDs()
        {
            var manager = new SoccerTeamsManager();
            var teamsIds = new List<long>() { 15, 2, 33, 4, 13 };

            for (int i = 0; i < teamsIds.Count(); i++)
                manager.AddTeam(teamsIds[i], "Time 1", DateTime.Now, "cor 1", "cor 2");

            teamsIds.Sort();
            Assert.Equal(teamsIds, manager.GetTeams());
        }

        [Theory]
        [InlineData("10,20,300,40,50", 2)]
        [InlineData("50,240,240,1,50", 1)]
        [InlineData("10,22,24,3,24", 2)]
        public void GetHigherSalaryPlayerTest(string salary, int topSalaryPlayerId)
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");

            var salarylList = salary.Split(',').Select(x => int.Parse(x)).ToList();
            for (int i = 0; i < salarylList.Count(); i++)
                manager.AddPlayer(i, 1, $"Jogador {i}", DateTime.Today, 10, salarylList[i]);

            Assert.Equal(topSalaryPlayerId, manager.GetHigherSalaryPlayer(1));
        }

        [Fact]
        public void GetHigherSalaryPlayer_Time_Nao_Encontrado()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddPlayer(1, 1, "Jogador 1", DateTime.Today, 0, 0);

            Assert.Throws<TeamNotFoundException>(() =>
                manager.GetHigherSalaryPlayer(2));
        }

        [Fact]
        public void GetTopPlayers_Top_8()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddTeam(2, "Time 2", DateTime.Now, "cor 1", "cor 2");
            manager.AddTeam(3, "Time 3", DateTime.Now, "cor 1", "cor 2");

            manager.AddPlayer(1, 1, "Jogador", DateTime.Today, 10, 10);
            manager.AddPlayer(2, 1, "Jogador", DateTime.Today, 05, 10);
            manager.AddPlayer(3, 1, "Jogador", DateTime.Today, 30, 10);
            manager.AddPlayer(4, 2, "Jogador", DateTime.Today, 50, 10);
            manager.AddPlayer(5, 2, "Jogador", DateTime.Today, 10, 10);
            manager.AddPlayer(6, 2, "Jogador", DateTime.Today, 40, 10);
            manager.AddPlayer(7, 3, "Jogador", DateTime.Today, 10, 10);
            manager.AddPlayer(8, 3, "Jogador", DateTime.Today, 50, 10);
            manager.AddPlayer(9, 3, "Jogador", DateTime.Today, 05, 05);

            var topPlayerId = new List<long>
            {
                4, 8, 6, 3, 1, 5, 7, 2
            };

            var result = manager.GetTopPlayers(8);
            Assert.Equal(topPlayerId, result);
        }

        [Fact]
        public void GetTopPlayers_Top_0()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddTeam(2, "Time 2", DateTime.Now, "cor 1", "cor 2");
            manager.AddTeam(3, "Time 3", DateTime.Now, "cor 1", "cor 2");

            manager.AddPlayer(4, 2, "Jogador", DateTime.Today, 50, 10);
            manager.AddPlayer(6, 2, "Jogador", DateTime.Today, 40, 10);
            manager.AddPlayer(8, 3, "Jogador", DateTime.Today, 50, 10);

            var topPlayerId = new List<long>();

            Assert.Equal(topPlayerId, manager.GetTopPlayers(0));
        }

        [Fact]
        public void GetTopPlayers_Sem_Jogadores()
        {
            var manager = new SoccerTeamsManager();
            manager.AddTeam(1, "Time 1", DateTime.Now, "cor 1", "cor 2");
            manager.AddTeam(2, "Time 2", DateTime.Now, "cor 1", "cor 2");
            manager.AddTeam(3, "Time 3", DateTime.Now, "cor 1", "cor 2");

            var topPlayerId = new List<long>();

            Assert.Equal(topPlayerId, manager.GetTopPlayers(10));
        }


    }
}
