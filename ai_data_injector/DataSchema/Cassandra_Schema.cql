CREATE KEYSPACE IF NOT EXISTS system
    WITH REPLICATION = { 
        'class' : 'SimpleStrategy', 
        'replication_factor' : 1
};

CREATE TABLE IF NOT EXISTS system.system_maintenance (
    key uuid PRIMARY KEY,
    data text,
    date timestamp
);