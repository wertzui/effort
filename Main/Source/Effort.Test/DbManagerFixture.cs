﻿// --------------------------------------------------------------------------------------------
// <copyright file="DbConfigurationFixture.cs" company="Effort Team">
//     Copyright (C) 2011-2014 Effort Team
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in
//     all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//     THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------

namespace Effort.Test
{
    using System;
    using System.Linq;
    using Effort.Provider;
    using Effort.Test.Data.Features;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class DbManagerFixture
    {
        [Test]
        public void DbManager_SetIdentityFields()
        {
            EffortConnection connection =
                (EffortConnection)DbConnectionFactory.CreateTransient();

            FeatureDbContext context = new FeatureDbContext(connection);
            context.Database.Initialize(true);

            {
                // Create a separate context for initializing the data (schema without 
                // identity field)
                FeatureDbContext dataInitContext = 
                    new FeatureDbContext(connection, CompiledModels.DisabledIdentityModel);

                // DbConfiguration require open connection
                connection.Open();
                // Disable identity fields
                connection.DbManager.SetIdentityFields(false);
                // Clear migration history to avoid exception
                connection.DbManager.ClearMigrationHistory();
                // EF cannot handle open connection (fixed in EF6)
                connection.Close();

                // Add data with explicitly set id
                var initEntity = new StringFieldEntity { Id = 5, Value = "Car" };
                dataInitContext.StringFieldEntities.Add(initEntity);
                dataInitContext.SaveChanges();

                // Identity generation should not be used
                Assert.AreEqual(5, initEntity.Id);

                // Enable identity field
                connection.Open();
                connection.DbManager.SetIdentityFields(true);
                connection.Close();
            }

            var entity = new StringFieldEntity { Id = 0, Value = "Bicycle" };
            context.StringFieldEntities.Add(entity);
            context.SaveChanges();

            // Identity generation should be used
            Assert.AreEqual(6, entity.Id);
        }

        [Test]
        public void DbManager_ClearTables()
        {
            var connection = (EffortConnection)DbConnectionFactory.CreateTransient();

            var model = CompiledModels.GetModel<RelationEntity, EmptyEntity>();
            var context = new FeatureDbContext(connection, model);

            context.Database.Initialize(true);

            context.RelationEntities.Add(
                new RelationEntity
                {
                    RequiredRelation = new EmptyEntity()
                });

            context.SaveChanges();

            // Create new context
            context = new FeatureDbContext(connection, model);

            // The records should be in
            context.EmptyEntities.Count().Should().Be(1);
            context.RelationEntities.Count().Should().Be(1);

            // Use DbManager to delete all data from the database
            connection.Open();
            connection.DbManager.ClearTables();

            // Tables should be empty
            context.EmptyEntities.Count().Should().Be(0);
            context.RelationEntities.Count().Should().Be(0);
        }
    }
}
