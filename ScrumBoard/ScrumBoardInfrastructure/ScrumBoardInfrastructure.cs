// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ScrumBoard;
using ScrumBoardInfrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ScrumBoardInfrastructure;

public class ScrumBoardContext : DbContext
{
    public DbSet<BoardModel> Boards => Set<BoardModel>();
    public DbSet<BoardColumnModel> BoardColumns => Set<BoardColumnModel>();
    public DbSet<BoardCardModel> BoardCards => Set<BoardCardModel>();

    public ScrumBoardContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=!safe_Password1?;database=lab5;",
                new MySqlServerVersion(new Version(5, 7, 29)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Board>();
        modelBuilder.Ignore<BoardColumn>();
        modelBuilder.Ignore<BoardCard>();
    }
}
