using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWarehouse.Library.Classes.Common;
using DataWarehouse.Library.Classes.Pokemon;
using MySqlConnector;

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
                // string query = @"SELECT event_name FROM pokemon_events;";
                // string query = @"SELECT event_id, 
                //                         event_name,
                //                         event_type
                //                  FROM pokemon_events;";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    int eventIDOrdinal = reader.GetOrdinal("event_id");
                    int isEventActiveOrdinal = reader.GetOrdinal("is_event_active");
                    int eventNameOrdinal = reader.GetOrdinal("event_name");
                    int eventTypeOrdinal = reader.GetOrdinal("event_type");
                    int startDateOrdinal = reader.GetOrdinal("start_date");
                    int endDateOrdinal = reader.GetOrdinal("end_date");
                    int serialCodeOrdinal = reader.GetOrdinal("serial_code");
                    int descriptionOrdinal = reader.GetOrdinal("description");
                    int createdDateOrdinal = reader.GetOrdinal("created_date");
                    int createdByOrdinal = reader.GetOrdinal("created_by");
                    int updatedDateOrdinal = reader.GetOrdinal("updated_date");
                    int updatedByOrdinal = reader.GetOrdinal("updated_by");
                    int isDeletedOrdinal = reader.GetOrdinal("is_deleted");

                    while (reader.Read())
                    {
                        int eventID = reader.GetInt32(eventIDOrdinal);
                        bool isEventActive = reader.GetBoolean(isEventActiveOrdinal);
                        string eventName = reader.GetString(eventNameOrdinal);
                        string eventType = reader.GetString(eventTypeOrdinal);
                        DateTime startDate = reader.GetDateTime(startDateOrdinal);
                        DateTime endDate = reader.GetDateTime(endDateOrdinal);
                        string serialCode = reader.IsDBNull(serialCodeOrdinal) ? string.Empty : reader.GetString(serialCodeOrdinal);
                        string description = reader.IsDBNull(descriptionOrdinal) ? string.Empty : reader.GetString(descriptionOrdinal);
                        DateTime createdDate = reader.GetDateTime(createdDateOrdinal);
                        string createdBy = reader.IsDBNull(createdByOrdinal) ? string.Empty : reader.GetString(createdByOrdinal);
                        DateTime updatedDate = reader.GetDateTime(updatedDateOrdinal);
                        string updatedBy = reader.IsDBNull(updatedByOrdinal) ? string.Empty : reader.GetString(updatedByOrdinal);
                        bool isDeleted = reader.GetBoolean(isDeletedOrdinal);

                        // PokemonEvent tempEvent = new(eventID, isEventActive, eventName, eventType, startDate, endDate, serialCode, description, createdDate, createdBy, updatedDate, updatedBy, isDeleted);

                        PokemonEvent tempEvent = new()
                        {
                            EventID = eventID,
                            IsEventActive = isEventActive,
                            EventName = eventName,
                            EventType = eventType,
                            StartDate = startDate,
                            EndDate = endDate,
                            SerialCode = serialCode,
                            Description = description,
                            AuditInfo = new AuditInfo(createdDate, createdBy, updatedDate, updatedBy, isDeleted)
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