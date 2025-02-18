﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Tourism.DataAccess;
using Tourism.Models;

namespace Tourism.FeatureTests
{
    public class StateCRUDTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public StateCRUDTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Index_ReturnsAllStates()
        {
            var context = GetDbContext();
            var client = _factory.CreateClient();

            context.States.Add(new State { Name = "Iowa", Abbreviation = "IA" });
            context.States.Add(new State { Name = "Colorado", Abbreviation = "CO" });
            context.SaveChanges();

            var response = await client.GetAsync("/states");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("IA", html);
            Assert.Contains("Iowa", html);
            Assert.Contains("CO", html);
            Assert.Contains("Colorado", html);
            Assert.DoesNotContain("California", html);
        }

        private TourismContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TourismContext>();
            optionsBuilder.UseInMemoryDatabase("TestDatabase");

            var context = new TourismContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

        [Fact]
        public async Task Show_ReturnsSelectedStateInfo()
        {
            var client = _factory.CreateClient();

            var context = GetDbContext();

            context.States.Add(new State { Name = "Illinois", Abbreviation = "IL" });
            context.SaveChanges();

            var response = await client.GetAsync("/states/1");
            var html = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Contains("Illinois", html);
            Assert.Contains("IL", html);
            Assert.DoesNotContain("California", html);
        }
    }
}
