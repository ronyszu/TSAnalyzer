using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITimeSeries
    {

        ITimeSeriesEntry[] ITimeSeries { get; set; }

    }


    public interface ITimeSeriesEntry : IEntity
    {

        DateTime Timestamp { get; set; }


        double Value { get; set; }



    }
}
