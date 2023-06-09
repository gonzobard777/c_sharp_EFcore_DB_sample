﻿using Domain.Interfaces;

namespace Domain;

public class License : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
}