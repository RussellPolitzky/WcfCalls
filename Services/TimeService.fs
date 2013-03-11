namespace Services

open System
open System.ServiceModel
open System.ServiceModel.Description
open DataContracts

type TimeService() =
    interface ITimeService with
        member this.GetTime() =
            DateTime.Now
