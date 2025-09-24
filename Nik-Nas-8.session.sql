CREATE TABLE pokemon_events 
(
    event_id            INT             PRIMARY KEY,
    is_event_active     BIT             NOT NULL,
    event_name          VARCHAR(100)    NOT NULL,
    event_type          VARCHAR(100)    NOT NULL,
    start_date          DATE            NOT NULL,
    end_date            DATE            NOT NULL,
    serial_code         VARCHAR(50)     NOT NULL,
    description         VARCHAR(250)    NULL,
    created_date        TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    created_by          VARCHAR(50)     NULL,
    updated_date        TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    updated_by          VARCHAR(50)     NULL,
    is_deleted          BOOLEAN         DEFAULT TRUE
);

ALTER TABLE pokemon_events ADD CONSTRAINT C_U_EVENT UNIQUE (event_name);

drop table pokemon_events;