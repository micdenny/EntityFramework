// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity.Metadata
{
    public class RelationalSequenceBuilder
    {
        private readonly Sequence _sequence;

        public RelationalSequenceBuilder([NotNull] Sequence sequence)
        {
            Check.NotNull(sequence, nameof(sequence));

            _sequence = sequence;
        }

        public virtual Sequence Metadata => _sequence;

        public virtual RelationalSequenceBuilder IncrementsBy(int increment)
        {
            _sequence.IncrementBy = increment;

            return this;
        }

        public virtual RelationalSequenceBuilder StartsAt(long startValue)
        {
            _sequence.StartValue = startValue;

            return this;
        }

        public virtual RelationalSequenceBuilder HasMax(long maximum)
        {
            _sequence.MaxValue = maximum;

            return this;
        }

        public virtual RelationalSequenceBuilder HasMin(long minimum)
        {
            _sequence.MinValue = minimum;

            return this;
        }

        public virtual RelationalSequenceBuilder IsCyclic(bool isCyclic = true)
        {
            _sequence.IsCyclic = isCyclic;

            return this;
        }
    }
}
