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
                string query = @"SELECT event_id,
                                        is_event_active,
                                        event_name,
                                        event_type,
                                        start_date,
                                        end_date,
                                        serial_code,
                                        description,
                                        created_date,
                                        created_by,
                                        updated_date,
                                        updated_by,
                                        is_deleted
                                 FROM pokemon_events;";
                //string query = @"SELECT event_name FROM pokemon_events;";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int eventID = reader.GetInt32("event_id");
                        bool isEventActive = bool.Parse(reader.GetString("is_event_active"));
                        string eventName = reader.GetString("event_name");
                        // string eventType = reader.GetString("event_type");
                        // DateTime startDate = reader.GetDateTime("start_date");
                        // DateTime endDate = reader.GetDateTime("end_date");
                        // string serialCode = reader.IsDBNull(reader.GetOrdinal("serial_code")) ? string.Empty : reader.GetString("serial_code");
                        // string description = reader.GetString("description") ?? "";
                        // DateTime createdDate = reader.GetDateTime("created_date");
                        // string createdBy = reader.GetString("created_by") ?? "";
                        // DateTime updatedDate = reader.GetDateTime("updated_date");
                        // string updatedBy = reader.IsDBNull(reader.GetOrdinal("updated_by")) ? string.Empty : reader.GetString("updated_by");
                        // bool isDeleted = reader.GetBoolean("is_deleted");

                        // AuditInfo tempAuditInfo = new(createdDate, createdBy, updatedDate, updatedBy, isDeleted);
                        // PokemonEvent tempEvent = new(eventID, isEventActive, eventName, eventType, startDate, endDate, serialCode, description, tempAuditInfo);

                        PokemonEvent tempEvent = new()
                        {
                            EventID = eventID,
                            IsEventActive = isEventActive,
                            EventName = eventName
                        };
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