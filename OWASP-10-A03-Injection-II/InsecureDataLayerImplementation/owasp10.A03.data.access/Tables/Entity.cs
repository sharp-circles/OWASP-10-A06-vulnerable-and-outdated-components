﻿using SQLite;

namespace owasp10.A03.data.access.Tables;

public class Entity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public long Id { get; set; }
}
