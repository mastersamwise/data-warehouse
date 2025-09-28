CREATE TABLE finance_categories
(
    category_id             INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    category_name           VARCHAR(100)    NOT NULL
);

CREATE TABLE finance_accounts
(
    account_id              INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    account_name            VARCHAR(100)    NOT NULL
)

CREATE TABLE finance_confirmation_numbers
(
    confirmation_number_id  INT             NOT NULL AUTO_INCREMENT PRIMARY KEY,
    date_of_payment         DATE            NOT NULL    DEFAULT '1900-01-01',
    date_of_arrival         DATE            NULL,
    recipient               VARCHAR(200)    NOT NULL,
    category_id             INT             NULL,
    account_used_id         INT             NULL,
    amount                  DECIMAL         NULL,
    confirmation_number     VARCHAR(100)    NULL,
    comment                 VARCHAR(500)    NULL,
    created_date            DATE            NOT NULL,
    created_by              VARCHAR(200)    NOT NULL,
    updated_date            DATE            NULL,
    updated_by              VARCHAR(200)    NULL,
    is_deleted              BIT             NOT NULL    DEFAULT 0
)