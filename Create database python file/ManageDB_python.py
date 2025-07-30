import sqlite3

# --------------Function for create database--------------
def create_sqlite_database(db_file):
  """Creates a new SQLite database file."""
  conn = sqlite3.connect(db_file)
  cursor = conn.cursor()

  # Create tables or perform other operations here
  cursor.execute('''CREATE TABLE CHEMICAL_PRICE (
      ID int NOT NULL PRIMARY KEY,
      Chemical_Name TEXT,
      Price DOUBLE,
      Location TEXT,
      Comment TEXT
      )''')

  conn.commit()
  conn.close()

# --------------Function for insert database--------------
def insert_data(db_file, sql):
  """Inserts data into a SQLite database."""
  conn = sqlite3.connect(db_file)
  cursor = conn.cursor()

  # Assuming data is a list of tuples
  cursor.execute(sql)
  conn.commit()
  conn.close()
  
def read_file_into_list(file_path):
  with open(file_path, 'r') as file:
    lines = file.readlines()
  return lines

#----------------Main----------------
# Create Table:
filename = 'LCC_Database.db'
# create_sqlite_database(filename)
# Insert Data 
SQLfile_path = "SQL_Insert.txt"
data = read_file_into_list(SQLfile_path)
for val in data:
    sql_command = val
    insert_data(filename, sql_command)
    
    
# '''CREATE TABLE Sigma_Profile (ID int NOT NULL PRIMARY KEY, CAS_No TEXT, Sigma_Volume DOUBLE, Col2_1 DOUBLE, Col2_2 DOUBLE, Col2_3 DOUBLE, Col2_4 DOUBLE, Col2_5 DOUBLE, Col2_6 DOUBLE, Col2_7 DOUBLE, Col2_8 DOUBLE, Col2_9 DOUBLE, Col2_10 DOUBLE, Col2_11 DOUBLE, Col2_12 DOUBLE, Col2_13 DOUBLE, Col2_14 DOUBLE, Col2_15 DOUBLE, Col2_16 DOUBLE, Col2_17 DOUBLE, Col2_18 DOUBLE, Col2_19 DOUBLE, Col2_20 DOUBLE, Col2_21 DOUBLE, Col2_22 DOUBLE, Col2_23 DOUBLE, Col2_24 DOUBLE, Col2_25 DOUBLE, Col2_26 DOUBLE, Col2_27 DOUBLE, Col2_28 DOUBLE, Col2_29 DOUBLE, Col2_30 DOUBLE, Col2_31 DOUBLE, Col2_32 DOUBLE, Col2_33 DOUBLE, Col2_34 DOUBLE, Col2_35 DOUBLE, Col2_36 DOUBLE, Col2_37 DOUBLE, Col2_38 DOUBLE, Col2_39 DOUBLE, Col2_40 DOUBLE, Col2_41 DOUBLE, Col2_42 DOUBLE, Col2_43 DOUBLE, Col2_44 DOUBLE, Col2_45 DOUBLE, Col2_46 DOUBLE, Col2_47 DOUBLE, Col2_48 DOUBLE, Col2_49 DOUBLE, Col2_50 DOUBLE, Col2_51 DOUBLE, Col3_1 DOUBLE, Col3_2 DOUBLE, Col3_3 DOUBLE, Col3_4 DOUBLE, Col3_5 DOUBLE, Col3_6 DOUBLE, Col3_7 DOUBLE, Col3_8 DOUBLE, Col3_9 DOUBLE, Col3_10 DOUBLE, Col3_11 DOUBLE, Col3_12 DOUBLE, Col3_13 DOUBLE, Col3_14 DOUBLE, Col3_15 DOUBLE, Col3_16 DOUBLE, Col3_17 DOUBLE, Col3_18 DOUBLE, Col3_19 DOUBLE, Col3_20 DOUBLE, Col3_21 DOUBLE, Col3_22 DOUBLE, Col3_23 DOUBLE, Col3_24 DOUBLE, Col3_25 DOUBLE, Col3_26 DOUBLE, Col3_27 DOUBLE, Col3_28 DOUBLE, Col3_29 DOUBLE, Col3_30 DOUBLE, Col3_31 DOUBLE, Col3_32 DOUBLE, Col3_33 DOUBLE, Col3_34 DOUBLE, Col3_35 DOUBLE, Col3_36 DOUBLE, Col3_37 DOUBLE, Col3_38 DOUBLE, Col3_39 DOUBLE, Col3_40 DOUBLE, Col3_41 DOUBLE, Col3_42 DOUBLE, Col3_43 DOUBLE, Col3_44 DOUBLE, Col3_45 DOUBLE, Col3_46 DOUBLE, Col3_47 DOUBLE, Col3_48 DOUBLE, Col3_49 DOUBLE, Col3_50 DOUBLE, Col3_51 DOUBLE, Col4_1 DOUBLE, Col4_2 DOUBLE, Col4_3 DOUBLE, Col4_4 DOUBLE, Col4_5 DOUBLE, Col4_6 DOUBLE, Col4_7 DOUBLE, Col4_8 DOUBLE, Col4_9 DOUBLE, Col4_10 DOUBLE, Col4_11 DOUBLE, Col4_12 DOUBLE, Col4_13 DOUBLE, Col4_14 DOUBLE, Col4_15 DOUBLE, Col4_16 DOUBLE, Col4_17 DOUBLE, Col4_18 DOUBLE, Col4_19 DOUBLE, Col4_20 DOUBLE, Col4_21 DOUBLE, Col4_22 DOUBLE, Col4_23 DOUBLE, Col4_24 DOUBLE, Col4_25 DOUBLE, Col4_26 DOUBLE, Col4_27 DOUBLE, Col4_28 DOUBLE, Col4_29 DOUBLE, Col4_30 DOUBLE, Col4_31 DOUBLE, Col4_32 DOUBLE, Col4_33 DOUBLE, Col4_34 DOUBLE, Col4_35 DOUBLE, Col4_36 DOUBLE, Col4_37 DOUBLE, Col4_38 DOUBLE, Col4_39 DOUBLE, Col4_40 DOUBLE, Col4_41 DOUBLE, Col4_42 DOUBLE, Col4_43 DOUBLE, Col4_44 DOUBLE, Col4_45 DOUBLE, Col4_46 DOUBLE, Col4_47 DOUBLE, Col4_48 DOUBLE, Col4_49 DOUBLE, Col4_50 DOUBLE, Col4_51 DOUBLE, Col5_1 DOUBLE, Col5_2 DOUBLE, Col5_3 DOUBLE, Col5_4 DOUBLE, Col5_5 DOUBLE, Col5_6 DOUBLE, Col5_7 DOUBLE, Col5_8 DOUBLE, Col5_9 DOUBLE, Col5_10 DOUBLE, Col5_11 DOUBLE, Col5_12 DOUBLE, Col5_13 DOUBLE, Col5_14 DOUBLE, Col5_15 DOUBLE, Col5_16 DOUBLE, Col5_17 DOUBLE, Col5_18 DOUBLE, Col5_19 DOUBLE, Col5_20 DOUBLE, Col5_21 DOUBLE, Col5_22 DOUBLE, Col5_23 DOUBLE, Col5_24 DOUBLE, Col5_25 DOUBLE, Col5_26 DOUBLE, Col5_27 DOUBLE, Col5_28 DOUBLE, Col5_29 DOUBLE, Col5_30 DOUBLE, Col5_31 DOUBLE, Col5_32 DOUBLE, Col5_33 DOUBLE, Col5_34 DOUBLE, Col5_35 DOUBLE, Col5_36 DOUBLE, Col5_37 DOUBLE, Col5_38 DOUBLE, Col5_39 DOUBLE, Col5_40 DOUBLE, Col5_41 DOUBLE, Col5_42 DOUBLE, Col5_43 DOUBLE, Col5_44 DOUBLE, Col5_45 DOUBLE, Col5_46 DOUBLE, Col5_47 DOUBLE, Col5_48 DOUBLE, Col5_49 DOUBLE, Col5_50 DOUBLE, Col5_51 DOUBLE)'''