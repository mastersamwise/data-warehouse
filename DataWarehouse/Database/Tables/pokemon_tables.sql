/***************************************************************************************
*       Pokemon Events
***************************************************************************************/
CREATE TABLE pokemon_events 
(
    event_id            INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    is_event_active     BOOLEAN         NOT NULL DEFAULT 0,
    applicable_game     VARCHAR(50)     NOT NULL,
    event_name          VARCHAR(100)    NOT NULL,
    event_type          VARCHAR(100)    NOT NULL,
    start_date          DATE            NOT NULL,
    end_date            DATE            NULL DEFAULT '2525-01-01 00:00:00',
    tera_type           VARCHAR(20)     NULL DEFAULT '-',
    serial_code         VARCHAR(50)     NULL DEFAULT '-',
    description         VARCHAR(250)    NULL,
    created_date        TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    created_by          VARCHAR(50)     NULL,
    updated_date        TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    updated_by          VARCHAR(50)     NULL,
    is_deleted          BOOLEAN         DEFAULT FALSE
);
ALTER TABLE pokemon_events ADD CONSTRAINT C_U_EVENT UNIQUE (event_name, start_date, serial_code);

/***************************************************************************************
*       Pokemon Species
***************************************************************************************/
CREATE TABLE pokemon_species
(
    id                      INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    species_name            VARCHAR(50)     NOT NULL,
    national_dex_number     INT             NOT NULL,
    has_alt_form            BIT             DEFAULT FALSE,
    description             VARCHAR(250)    NULL,
    comment                 VARCHAR(500)    NULL,
    created_date            TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    created_by              VARCHAR(50)     NULL,
    updated_date            TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    updated_by              VARCHAR(50)     NULL,
    is_deleted              BOOLEAN         DEFAULT FALSE
);
ALTER TABLE pokemon_species ADD CONSTRAINT c_u_pokemon_species UNIQUE (event_name, start_date, serial_code);

/***************************************************************************************
*       Alternate Pokemon Forms
***************************************************************************************/
CREATE TABLES alternate_pokemon_forms
(
    id                      INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    form_name               VARCHAR(100)    NOT NULL,
    species_id              INT             NOT NULL,
    comment                 VARCHAR(500)    NULL,
    created_date            TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    created_by              VARCHAR(50)     NULL,
    updated_date            TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    updated_by              VARCHAR(50)     NULL,
    is_deleted              BOOLEAN         DEFAULT FALSE
);
ALTER TABLE alternate_pokemon_forms ADD CONSTRAINT c_u_alternate_pokemon_forms UNIQUE (form_name);

/***************************************************************************************
*       Pokemon Games
***************************************************************************************/
CREATE TABLE pokemon_games
(
    id                  INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    game_name           VARCHAR(50)     NOT NULL,
    platform            VARCHAR(50)     NOT NULL,
    release_date        TIMESTAMP       NULL,
    comment             VARCHAR(500)    NULL,
    created_date        TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    created_by          VARCHAR(50)     NULL,
    updated_date        TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    updated_by          VARCHAR(50)     NULL,
    is_deleted          BOOLEAN         DEFAULT FALSE
);
ALTER TABLE pokemon_games ADD CONSTRAINT c_u_pokemon_games UNIQUE (game_name);

/***************************************************************************************
*       Pokemon with Applicable Games
***************************************************************************************/
CREATE TABLE pokemon_with_applicable_games
(
    species_id          INT             NOT NULL,
    game_id             INT             NOT NULL,
    is_in_game          BIT             DEFAULT FALSE,
    comment             VARCHAR(500)    NULL,
    created_date        TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    created_by          VARCHAR(50)     NULL,
    updated_date        TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    updated_by          VARCHAR(50)     NULL,
    is_deleted          BOOLEAN         DEFAULT FALSE
);
ALTER TABLE pokemon_with_applicable_games ADD CONSTRAINT c_u_pokemon_with_applicable_games UNIQUE (species_id, game_id);

/***************************************************************************************
*       National Dex Checklist
***************************************************************************************/
CREATE TABLE national_dex_checklist
(
    id                          INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    species_id                  INT             NOT NULL,
    is_registered_in_home       BIT             DEFAULT FALSE,
    is_in_living_dex            BIT             DEFAULT FALSE,
    is_shiny_in_living_dex      BIT             DEFAULT FALSE,
    has_hidden_ability_in_home  BIT             DEFAULT FALSE,
    comment                     VARCHAR(1000)   NULL,
    created_date                TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    created_by                  VARCHAR(50)     NULL,
    updated_date                TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    updated_by                  VARCHAR(50)     NULL,
    is_deleted                  BOOLEAN         DEFAULT FALSE
);

/***************************************************************************************
*       National Dex Checklist Raw Import
***************************************************************************************/
CREATE TABLE national_dex_checklist_raw_import
(
    id                          INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    pokemon_name                VARCHAR(100)    NOT NULL,
    is_registered_in_home       VARCHAR(100),
    is_in_living_dex            VARCHAR(100),
    is_shiny_in_living_dex      VARCHAR(100),
    has_hidden_ability_in_home  VARCHAR(100),
    is_pokemon_in_lgfr          VARCHAR(100),
    is_pokemon_in_swsh          VARCHAR(100),
    is_pokemon_in_bdsp          VARCHAR(100),
    is_pokemon_in_arceus        VARCHAR(100),
    is_pokemon_in_sv            VARCHAR(100),
    is_pokemon_in_za            VARCHAR(100),
    comment                     VARCHAR(1000)   NULL,
    created_date                TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    created_by                  VARCHAR(50)     NULL,
    updated_date                TIMESTAMP       DEFAULT CURRENT_TIMESTAMP,
    updated_by                  VARCHAR(50)     NULL,
    is_deleted                  BOOLEAN         DEFAULT FALSE
);
