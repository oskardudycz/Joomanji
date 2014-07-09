using System;

namespace Shared.Objects.Dates
{
    public interface IDateRange
    {
        DateTime? StartDate { get; }

        DateTime? EndDate { get; }
    }
}