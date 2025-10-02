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
        private readonly string connectionString = Constants.DB_CONNECTION_NAS;

        public PokemonManager()
        {

        }

        /// <summary>
        /// Fetch all Active Pokemon Events
        /// </summary>
        /// <returns></returns>
        public List<PokemonEvent> GetActivePokemonEvents()
        {
            List<PokemonEvent> events = new List<PokemonEvent>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                            SELECT  event_id,
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
                            FROM pokemon_events
                            WHERE is_event_active  = true
                                AND end_date >= CURDATE()
                                AND is_deleted = false;";

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
                    Console.WriteLine($"[GetActivePokemonEvents()] \t Error: {ex.Message}");
                }

                Console.WriteLine($"[GetActivePokemonEvents()] \t Returning {events.Count} events");
                return events;
            }
        }

        /// <summary>
        /// Fetch all Pokemon Events
        /// </summary>
        /// <returns></returns>
        public List<PokemonEvent> GetPokemonEvents()
        {
            List<PokemonEvent> events = new List<PokemonEvent>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                            SELECT  event_id,
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

        /// <summary>
        /// Retrieve data for the Pokemon Event with the specified eventID
        /// </summary>
        /// <param name="inEventID">ID of the Pokemon Event to retrieve</param>
        /// <returns></returns>
        public PokemonEvent GetPokemonEventByID(int inEventID)
        {
            PokemonEvent pokemonEvent = new PokemonEvent();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                            SELECT  event_id,
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
                            FROM pokemon_events
                            WHERE event_id = @eventID;";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@eventID", inEventID);

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

                        pokemonEvent = new()
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
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[GetPokemonEventID()] \t Error: {ex.Message}");
                }

                Console.WriteLine($"[GetPokemonEventID()] \t Returning data for {pokemonEvent.EventName} event");
                return pokemonEvent;
            }
        }

        /// <summary>
        /// Add a Pokemon Event
        /// </summary>
        /// <param name="inEvent">Add the supplied Pokemon Event to the database</param>
        /// <returns></returns>
        public DatabaseResult AddPokemonEvent(PokemonEvent inEvent)
        {
            DatabaseResult dbResult = new DatabaseResult();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO pokemonEvents
                    (
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
                    )
                    VALUES
                    (
                        @isEventActive,
                        @eventName,
                        @eventType,
                        @startDate,
                        @endDate,
                        @serialCode,
                        @description,
                        @createdDate,
                        @createdBy,
                        @updatedDate,
                        @updatedBy,
                        @isDeleted
                    );";

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@isEventActive", inEvent.IsEventActive);
                    command.Parameters.AddWithValue("@eventName", inEvent.EventName);
                    command.Parameters.AddWithValue("@eventType", inEvent.EventType);
                    command.Parameters.AddWithValue("@startDate", inEvent.StartDate);
                    command.Parameters.AddWithValue("@endDate", inEvent.EndDate);
                    command.Parameters.AddWithValue("@serialCode", inEvent.SerialCode);
                    command.Parameters.AddWithValue("@description", inEvent.Description);
                    command.Parameters.AddWithValue("@createdDate", inEvent.AuditInfo.createdDate);
                    command.Parameters.AddWithValue("@createdBy", inEvent.AuditInfo.createdBy);
                    command.Parameters.AddWithValue("@updatedDate", inEvent.AuditInfo.updatedDate);
                    command.Parameters.AddWithValue("@updatedBy", inEvent.AuditInfo.updatedBy);
                    command.Parameters.AddWithValue("@isDeleted", inEvent.AuditInfo.isDeleted);

                    command.ExecuteNonQuery();

                    dbResult.id = inEvent.EventID;
                    dbResult.wasCallSuccessful = true;
                    dbResult.updatedDate = inEvent.AuditInfo.updatedDate;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[AddPokemonEvent()] \t Error: {ex.Message}");
                }

                Console.WriteLine($"[AddPokemonEvent()] \t Added data for {inEvent.EventName} event");
            }

            return dbResult;
        }

        /// <summary>
        /// Update the Pokemon Event in the database with the PokmeonEvent supplied
        /// </summary>
        /// <param name="inEvent">Pokemon Event</param>
        /// <returns></returns>
        public DatabaseResult UpdatePokemonEvent(PokemonEvent inEvent)
        {
            DatabaseResult dbResult = new DatabaseResult();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                    UPDATE pokemonEvents
                    SET
                        is_event_active     = @isEventActive,
                        event_name          = @eventName,
                        event_type          = @eventType,
                        start_date          = @startDate,
                        end_date            = @endDate,
                        serial_code         = @serialCode,
                        description         = @description,
                        updated_date        = @updatedDate,
                        updated_by          = @updatedBy
                    WHERE event_id = @eventID;";

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@isEventActive", inEvent.IsEventActive);
                    command.Parameters.AddWithValue("@eventName", inEvent.EventName);
                    command.Parameters.AddWithValue("@eventType", inEvent.EventType);
                    command.Parameters.AddWithValue("@startDate", inEvent.StartDate);
                    command.Parameters.AddWithValue("@endDate", inEvent.EndDate);
                    command.Parameters.AddWithValue("@serialCode", inEvent.SerialCode);
                    command.Parameters.AddWithValue("@description", inEvent.Description);
                    command.Parameters.AddWithValue("@updatedDate", inEvent.AuditInfo.updatedDate);
                    command.Parameters.AddWithValue("@updatedBy", inEvent.AuditInfo.updatedBy);

                    command.Parameters.AddWithValue("@eventID", inEvent.EventID);

                    command.ExecuteNonQuery();

                    dbResult.id = inEvent.EventID;
                    dbResult.wasCallSuccessful = true;
                    dbResult.updatedDate = inEvent.AuditInfo.updatedDate;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[UpdatePokemonEvent()] \t Error: {ex.Message}");
                }

                Console.WriteLine($"[UpdatePokemonEvent()] \t Updated data for {inEvent.EventName} event");
            }

            return dbResult;
        }

        /// <summary>
        /// Perform a soft-delete on the supplied Pokemon Event
        /// </summary>
        /// <param name="inEvent">Pokemon Event</param>
        /// <returns></returns> 
        public DatabaseResult DeletePokemonEvent(PokemonEvent inEvent)
        {
            DatabaseResult dbResult = new DatabaseResult();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                    UPDATE pokemon_events
                    SET 
                        udpated_date    = @updatedDate,
                        udpated_by      = @updatedBy,
                        is_deleted      = @isDeleted
                    WHERE event_id = @eventID;";

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@updatedDate", inEvent.AuditInfo.updatedDate);
                    command.Parameters.AddWithValue("@updatedBy", inEvent.AuditInfo.updatedBy);
                    command.Parameters.AddWithValue("@isDeleted", true);

                    command.Parameters.AddWithValue("@eventID", inEvent.EventID);

                    command.ExecuteNonQuery();

                    dbResult.id = inEvent.EventID;
                    dbResult.wasCallSuccessful = true;
                    dbResult.updatedDate = inEvent.AuditInfo.updatedDate;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DeletePokemonEvent()] \t Error: {ex.Message}");
                }

                Console.WriteLine($"[DeletePokemonEvent()] \t Soft-Deleted Pokemon Event {inEvent.EventName} (with ID [{inEvent.EventID}])");
            }

            return dbResult;
        }
    }
}