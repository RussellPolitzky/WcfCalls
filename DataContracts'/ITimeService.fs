namespace DataContracts

open System
open System.ServiceModel
open System.ServiceModel.Description

[<ServiceContract>]
type ITimeService =
    [<OperationContract>]
    abstract member GetTime : unit -> DateTime