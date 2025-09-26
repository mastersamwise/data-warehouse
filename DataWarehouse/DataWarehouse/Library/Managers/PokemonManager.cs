using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWarehouse.Library.Classes.Common;
using DataWarehouse.Library.Classes.Pokemon;
using MySql.Data.MySqlClient;

namespace DataWarehouse.Library.Managers
{
    public class PokemonManager
    {
        private string connectionString = Constants.DB_CONNECTION_NAS;

        public PokemonManager()
        {
            
        }

        public List<PokemonEvent> GetPokemonEvents()
        {
            List<PokemonEvent> events = new List<PokemonEvent>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT event_name FROM pokemon_events;";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string eventName = reader.GetString("event_name");
                        Console.WriteLine($"Event name: {eventName}");
                        PokemonEvent tempEvent = new(eventName);

                        events.Add(tempEvent);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[GetPokemonEvents()] \t Error: {ex.Message}");
                }

                return events;
            }
        }
        
    }
}