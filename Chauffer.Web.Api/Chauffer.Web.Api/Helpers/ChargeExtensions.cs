using Chauffer.Web.Api.Models;
using System;
using System.Collections.Generic;

namespace Chauffer.Web.Api.Helpers
{
    public static class ChargeExtensions
    {
        public static decimal ToStopCharge(this StopReason stopReason, CarType carType, JobType jobType)
        {
            var reasonDict = new Dictionary<StopReason, decimal>();
            foreach(var reason in Enum.GetValues(typeof(StopReason)))
            {
                switch (reason)
                {
                    case StopReason.Emergency:
                        reasonDict.Add(StopReason.Emergency, 10);
                        break;
                    default:
                        reasonDict.Add(StopReason.Standard, 10);
                        break;
                }
            }

            var carTypeDict = new Dictionary<CarType, decimal>();
            foreach (var type in Enum.GetValues(typeof(CarType)))
            {
                switch (type)
                {
                    case CarType.FourDoor:
                        carTypeDict.Add(CarType.FourDoor, 10);
                        break;
                    case CarType.Luxury:
                        carTypeDict.Add(CarType.Luxury, 12);
                        break;
                    case CarType.MiniVan:
                        carTypeDict.Add(CarType.MiniVan, 14);
                        break;
                    case CarType.Sports:
                        carTypeDict.Add(CarType.Sports, 16);
                        break;
                    case CarType.TwoDoor:
                        carTypeDict.Add(CarType.TwoDoor, 14);
                        break;
                    case CarType.Wagon:
                        carTypeDict.Add(CarType.Wagon, 18);
                        break;
                }
            }

            var jobTypeDict = new Dictionary<JobType, decimal>();
            foreach (var type in Enum.GetValues(typeof(JobType)))
            {
                switch (type)
                {
                    case JobType.Standard:
                        jobTypeDict.Add(JobType.Standard, 1.5m);
                        break;
                    case JobType.AsDirected:
                        jobTypeDict.Add(JobType.AsDirected, 1.4m);
                        break;
                    case JobType.AirportTranfser:
                        jobTypeDict.Add(JobType.AirportTranfser, 1.6m);
                        break;
                    default:
                        jobTypeDict.Add(JobType.Standard, 1.4m);
                        break;
                }
            }

            var reasonCharge = reasonDict[stopReason];
            var carTypeCharge = carTypeDict[carType];
            var jobTypeCharge = jobTypeDict[jobType];

            return (reasonCharge + carTypeCharge) * jobTypeCharge;
        }
    }
}