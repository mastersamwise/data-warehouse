# 2026-03-14
# getting this code here: https://gemini.google.com/app/2a3d68dfb482bab3

import pandas as pd

def excel_to_typed_insert(file_path, sheet_name, table_name):
    # Load everything as string first to maintain control
    df = pd.read_excel(file_path, sheet_name=sheet_name, dtype=str)
    # df = df.fillna('NULL') # Use SQL NULL for empty cells
    null_values = ['n/a', 'na', 'none', '', 'null', 'nan']

    columns = ", ".join(df.columns)
    value_tuples = []

    for _, row in df.iterrows():
        formatted_values = []
        
        for col_name, val in row.items():
            # if val == 'NULL':
            #     formatted_values.append("NULL")
            #     continue
            
            # Clean the string value
            clean_val = str(val).replace("'", "''")
            is_null = pd.isna(clean_val) or clean_val in null_values

            # --- CUSTOM CASTING LOGIC ---
            if col_name == 'is_event_active': # BOOLEAN
                if is_null:
                    formatted_values.append("NULL")
                else:
                    # Converts 'true', '1', 'yes' to TRUE, else FALSE
                    is_true = clean_val.lower() in ['true', '1', 'yes', 'y']
                    formatted_values.append("TRUE" if is_true else "FALSE")

            # Don't need timestamp for pokemon events
            # elif col_name == 'col4': # TIMESTAMP
            #     if is_null:
            #         formatted_values.append("NULL")
            #     else:
            #     # Wraps in quotes and adds a CAST or prefix
            #     formatted_values.append(f"CAST('{clean_val}' AS TIMESTAMP)")
            
            elif col_name == 'start_date': # DATE
                if is_null:
                    clean_val = default_start_date
                formatted_values.append(f"CAST('{clean_val}' AS DATE)")
            
            elif col_name == 'end_date': # DATE
                if is_null:
                     clean_val = default_end_date
                formatted_values.append(f"CAST('{clean_val}' AS DATE)")

            else: # DEFAULT: Treat as STRING
                if is_null:
                    formatted_values.append("NULL")
                else:
                    formatted_values.append(f"'{clean_val}'")

        row_string = f"( {', '.join(formatted_values)} )"
        value_tuples.append(row_string)

    values_block = ",\n".join(value_tuples)
    insert_query = f"INSERT INTO {table_name} ( {columns} )\nVALUES\n{values_block};"

    return insert_query

# --- Run it ---
default_start_date = '1900-01-01 00:00:00'
default_end_date = '2525-01-01 00:00:00'

file = 'Resources/Pokemon.xlsx'
sheet_name = 'Events'
table_name = 'pokemon_events'
output_file = 'Output/insert_pokemon_events.sql'
sql_output = excel_to_typed_insert(file, sheet_name, table_name)

# Save the single large query to a file
with open(output_file, 'w') as f:
    f.write(sql_output)

print(f"Bulk insert query generated in '{output_file}'")