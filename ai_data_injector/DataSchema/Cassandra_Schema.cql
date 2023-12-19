CREATE KEYSPACE IF NOT EXISTS systemdata
    WITH REPLICATION = { 
        'class' : 'SimpleStrategy', 
        'replication_factor' : 1
};

CREATE TABLE IF NOT EXISTS systemdata.system_maintenance (
    key uuid PRIMARY KEY,
    data text,
    date timestamp
);