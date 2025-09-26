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
                        int eventID = int.Parse(reader.GetString("event_id"));
                        bool isEventActive = bool.Parse(reader.GetString("is_event_active"));
                        string eventName = reader.GetString("event_name");
                        string eventType = reader.GetString("event_type");
                        DateTime startDate = DateTime.Parse(reader.GetString("start_date"));
                        DateTime endDate = DateTime.Parse(reader.GetString("end_date"));
                        string serialCode = reader.GetString("serial_code");
                        string description = reader.GetString("description");
                        DateTime createdDate = DateTime.Parse(reader.GetString("created_date"));
                        string createdBy = reader.GetString("created_by");
                        DateTime updatedDate = DateTime.Parse(reader.GetString("updated_date"));
                        string updatedBy = reader.GetString("updated_by");
                        bool isDeleted = bool.Parse(reader.GetString("is_deleted"));

                        AuditInfo tempAuditInfo = new(createdDate, createdBy, updatedDate, updatedBy, isDeleted);
                        PokemonEvent tempEvent = new(eventID, isEventActive, eventName, eventType, startDate, endDate, serialCode, description, tempAuditInfo);

                        events.Add(tempEvent);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[GetPokemonEvents()] \t Error: {ex.Message}");
                }

                Console.WriteLine($"[GetPokemonEvents()] \t Returning {events.Count} events");
                return events;
            }
        }
        
    }
}