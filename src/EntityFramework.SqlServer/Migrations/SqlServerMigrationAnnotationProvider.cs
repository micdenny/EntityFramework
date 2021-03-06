﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace Microsoft.Data.Entity.SqlServer.Migrations
{
    public class SqlServerMigrationAnnotationProvider : MigrationAnnotationProvider
    {
        public override IEnumerable<IAnnotation> For(IKey key)
        {
            if (key.SqlServer().IsClustered.HasValue)
            {
                yield return new Annotation(
                     SqlServerAnnotationNames.Prefix + SqlServerAnnotationNames.Clustered,
                     key.SqlServer().IsClustered.Value);
            }
        }

        public override IEnumerable<IAnnotation> For(IIndex index)
        {
            if (index.SqlServer().IsClustered.HasValue)
            {
                yield return new Annotation(
                     SqlServerAnnotationNames.Prefix + SqlServerAnnotationNames.Clustered,
                     index.SqlServer().IsClustered.Value);
            }
        }

        public override IEnumerable<IAnnotation> For(IProperty property)
        {
            if (property.SqlServer().IdentityStrategy == SqlServerIdentityStrategy.IdentityColumn)
            {
                yield return new Annotation(
                    SqlServerAnnotationNames.Prefix + SqlServerAnnotationNames.ValueGenerationStrategy,
                    SqlServerIdentityStrategy.IdentityColumn);
            }
        }
    }
}
