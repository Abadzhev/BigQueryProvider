﻿using System;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Update;

namespace DevExpress.DataAccess.BigQuery.EntityFarmework7.Update
{
    using RelationalStrings = Microsoft.Data.Entity.Relational.Internal.Strings;

    /// <remarks>
    /// The usual ModificationCommandBatch implementation is <see cref="AffectedCountModificationCommandBatch"/>,
    /// which relies on <see cref="SqlGenerator.AppendSelectAffectedCountCommand"/> to fetch the number of
    /// rows modified via SQL.
    ///
    /// PostgreSQL actually has no way of selecting the modified row count.
    /// SQL defines GET DIAGNOSTICS which should provide this, but in PostgreSQL it's only available
    /// in PL/pgSQL. See http://www.postgresql.org/docs/9.4/static/unsupported-features-sql-standard.html,
    /// identifier F121-01.
    ///
    /// Instead, the affected row count can be accessed in the PostgreSQL protocol itself, which seems
    /// cleaner and more efficient anyway (no additional query).
    /// </remarks>
    /// TODO: Implement it
    public class BigQueryModificationCommandBatch : ReaderModificationCommandBatch
    {
        public BigQueryModificationCommandBatch([NotNull] IUpdateSqlGenerator sqlGenerator)
            : base(sqlGenerator)
        {}

        protected override bool CanAddCommand(ModificationCommand modificationCommand) {
            //return ModificationCommands.Count < BigQueryCommand.MaxStatements;
            return false; //TODO: Check it
        }

        protected override bool IsCommandTextValid()
            => true;

        protected override void Consume(DbDataReader reader, DbContext context)
        {
            //var npgsqlReader = (BigQueryDataReader)reader;
            //Debug.Assert(npgsqlReader.Statements.Count == ModificationCommands.Count, $"Reader has {npgsqlReader.Statements.Count} statements, expected {ModificationCommands.Count}");
            //var commandIndex = 0;

            //try
            //{
            //    while (true)
            //    {
            //        // Find the next propagating command, if any
            //        int nextPropagating;
            //        for (nextPropagating = commandIndex;
            //            nextPropagating < ModificationCommands.Count &&
            //            !ModificationCommands[nextPropagating].RequiresResultPropagation;
            //            nextPropagating++) ;

            //        // Go over all non-propagating commands before the next propagating one,
            //        // make sure they executed
            //        for (; commandIndex < nextPropagating; commandIndex++)
            //        {
            //            if (npgsqlReader.Statements[commandIndex].Rows == 0)
            //            {
            //                throw new DbUpdateConcurrencyException(
            //                    RelationalStrings.UpdateConcurrencyException(1, 0),
            //                    ModificationCommands[commandIndex].Entries
            //                );
            //            }
            //        }

            //        if (nextPropagating == ModificationCommands.Count)
            //        {
            //            Debug.Assert(!reader.NextResult(), "Expected less resultsets");
            //            break;
            //        }

            //        // Propagate to results from the reader to the ModificationCommand

            //        var modificationCommand = ModificationCommands[commandIndex++];

            //        if (!reader.Read())
            //        {
            //            // Should never happen? Aren't result-propagating modifications only INSERTs,
            //            // which either succeed or throw an exception (e.g. constraint violation)?
            //            throw new DbUpdateConcurrencyException(
            //                RelationalStrings.UpdateConcurrencyException(1, 0),
            //                modificationCommand.Entries);
            //        }

            //        modificationCommand.PropagateResults(modificationCommand.ValueBufferFactory.Create(reader));

            //        reader.NextResult();
            //    }
            //}
            //catch (DbUpdateException)
            //{
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    throw new DbUpdateException(
            //        RelationalStrings.UpdateStoreException,
            //        ex,
            //        ModificationCommands[commandIndex].Entries);
            //}
        }

        protected override async Task ConsumeAsync(
            DbDataReader reader,
            DbContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            //var npgsqlReader = (BigQueryDataReader)reader;
            //Debug.Assert(npgsqlReader.Statements.Count == ModificationCommands.Count, $"Reader has {npgsqlReader.Statements.Count} statements, expected {ModificationCommands.Count}");
            //var commandIndex = 0;

            //try
            //{
            //    while (true)
            //    {
            //        // Find the next propagating command, if any
            //        int nextPropagating;
            //        for (nextPropagating = commandIndex;
            //            nextPropagating < ModificationCommands.Count &&
            //            !ModificationCommands[nextPropagating].RequiresResultPropagation;
            //            nextPropagating++)
            //            ;

            //        // Go over all non-propagating commands before the next propagating one,
            //        // make sure they executed
            //        for (; commandIndex < nextPropagating; commandIndex++)
            //        {
            //            if (npgsqlReader.Statements[commandIndex].Rows == 0)
            //            {
            //                throw new DbUpdateConcurrencyException(
            //                    RelationalStrings.UpdateConcurrencyException(1, 0),
            //                    ModificationCommands[commandIndex].Entries
            //                );
            //            }
            //        }

            //        if (nextPropagating == ModificationCommands.Count)
            //        {
            //            Debug.Assert(!(await reader.NextResultAsync(cancellationToken)), "Expected less resultsets");
            //            break;
            //        }

            //        // Extract result from the command and propagate it

            //        var modificationCommand = ModificationCommands[commandIndex++];

            //        if (!(await reader.ReadAsync(cancellationToken)))
            //        {
            //            // Should never happen? Aren't result-propagating modifications only INSERTs,
            //            // which either succeed or throw an exception (e.g. constraint violation)?
            //            throw new DbUpdateConcurrencyException(
            //                RelationalStrings.UpdateConcurrencyException(1, 0),
            //                modificationCommand.Entries
            //            );
            //        }

            //        modificationCommand.PropagateResults(modificationCommand.ValueBufferFactory.Create(reader));

            //        await reader.NextResultAsync(cancellationToken);
            //    }
            //}
            //catch (DbUpdateException)
            //{
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    throw new DbUpdateException(
            //        RelationalStrings.UpdateStoreException,
            //        ex,
            //        ModificationCommands[commandIndex].Entries);
            //}
        }
    }
}
