// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Migrations.Operations;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity.Migrations.Builders
{
    public class ColumnsBuilder
    {
        private readonly CreateTableOperation _createTableOperation;

        public ColumnsBuilder([NotNull] CreateTableOperation createTableOperation)
        {
            Check.NotNull(createTableOperation, nameof(createTableOperation));

            _createTableOperation = createTableOperation;
        }

        public virtual OperationBuilder<AddColumnOperation> Column<T>(
            [CanBeNull] string type = null,
            [CanBeNull] string name = null,
            bool nullable = false,
            [CanBeNull] object defaultValue = null,
            [CanBeNull] string defaultValueSql = null,
            [CanBeNull] string computedColumnSql = null)
        {
            var operation = new AddColumnOperation
            {
                Schema = _createTableOperation.Schema,
                Table = _createTableOperation.Name,
                Name = name,
                ClrType = typeof(T),
                ColumnType = type,
                IsNullable = nullable,
                DefaultValue = defaultValue,
                DefaultValueSql = defaultValueSql,
                ComputedColumnSql = computedColumnSql
            };
            _createTableOperation.Columns.Add(operation);

            return new OperationBuilder<AddColumnOperation>(operation);
        }
    }
}
