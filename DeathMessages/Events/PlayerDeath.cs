using Microsoft.Extensions.Configuration;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Users;
using OpenMod.Unturned.Users.Events;
using OpenMod.Unturned.Players.Life.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeathMessages.Events
{
    public class PlayerDeath : IEventListener<UnturnedPlayerDeathEvent>
    {
        private readonly UnturnedUserDirectory m_UnturnedUserDirectory;
        private readonly IConfiguration m_Configuration;

        public PlayerDeath(UnturnedUserDirectory unturnedUserDirectory, IConfiguration configuration)
        {
            m_UnturnedUserDirectory = unturnedUserDirectory;
            m_Configuration = configuration;

        }

        public async Task HandleEventAsync(object sender, UnturnedPlayerDeathEvent @event)
        {
            string userName = @event.Player.Player.name.ToString();
            var deathMessage = "Has died";
            var deathCause = @event.DeathCause.ToString();

            switch (deathCause)
            {
                case "BLEEDING":
                    deathMessage = m_Configuration.GetSection("BLEEDING").Get<string>();
                    break;
                case "BONES":
                    deathMessage = m_Configuration.GetSection("BONES").Get<string>();
                    break;
                case "FREEZING":
                    deathMessage = m_Configuration.GetSection("FREEZING").Get<string>();
                    break;
                case "BURNING":
                    deathMessage = m_Configuration.GetSection("BURNING").Get<string>();
                    break;
                case "FOOD":
                    deathMessage = m_Configuration.GetSection("FOOD").Get<string>();
                    break;
                case "WATER":
                    deathMessage = m_Configuration.GetSection("WATER").Get<string>();
                    break;
                case "GUN":
                    deathMessage = m_Configuration.GetSection("GUN").Get<string>();
                    break;
                case "MELEE":
                    deathMessage = m_Configuration.GetSection("MELEE").Get<string>();
                    break;
                case "ZOMBIE":
                    deathMessage = m_Configuration.GetSection("ZOMBIE").Get<string>();
                    break;
                case "ANIMAL":
                    deathMessage = m_Configuration.GetSection("ANIMAL").Get<string>();
                    break;
                case "SUICIDE":
                    deathMessage = m_Configuration.GetSection("SUICIDE").Get<string>();
                    break;
                case "KILL":
                    deathMessage = m_Configuration.GetSection("KILL").Get<string>();
                    break;
                case "INFECTION":
                    deathMessage = m_Configuration.GetSection("INFECTION").Get<string>();
                    break;
                case "PUNCH":
                    deathMessage = m_Configuration.GetSection("PUNCH").Get<string>();
                    break;
                case "BREATH":
                    deathMessage = m_Configuration.GetSection("BREATH").Get<string>();
                    break;
                case "ROADKILL":
                    deathMessage = m_Configuration.GetSection("ROADKILL").Get<string>();
                    break;
                case "VEHICLE":
                    deathMessage = m_Configuration.GetSection("VEHICLE").Get<string>();
                    break;
                case "GRENADE":
                    deathMessage = m_Configuration.GetSection("GRENADE").Get<string>();
                    break;
                case "SHRED":
                    deathMessage = m_Configuration.GetSection("SHRED").Get<string>();
                    break;
                case "LANDMINE":
                    deathMessage = m_Configuration.GetSection("LANDMINE").Get<string>();
                    break;
                case "ARENA":
                    deathMessage = m_Configuration.GetSection("ARENA").Get<string>();
                    break;
                case "MISSILE":
                    deathMessage = m_Configuration.GetSection("MISSILE").Get<string>();
                    break;
                case "CHARGE":
                    deathMessage = m_Configuration.GetSection("CHARGE").Get<string>();
                    break;
                case "SPLASH":
                    deathMessage = m_Configuration.GetSection("SPLASH").Get<string>();
                    break;
                case "SENTRY":
                    deathMessage = m_Configuration.GetSection("SENTRY").Get<string>();
                    break;
                case "ACID":
                    deathMessage = m_Configuration.GetSection("ACID").Get<string>();
                    break;
                case "BOULDER":
                    deathMessage = m_Configuration.GetSection("BOULDER").Get<string>();
                    break;
                case "BURNER":
                    deathMessage = m_Configuration.GetSection("BURNER").Get<string>();
                    break;
                case "SPIT":
                    deathMessage = m_Configuration.GetSection("SPIT").Get<string>();
                    break;
                case "SPARK":
                    deathMessage = m_Configuration.GetSection("SPARK").Get<string>();
                    break;
            }
            
            Parallel.ForEach(m_UnturnedUserDirectory.GetOnlineUsers(),
                x => x.PrintMessageAsync($"{userName} {deathMessage}"));
        }
    }
}
